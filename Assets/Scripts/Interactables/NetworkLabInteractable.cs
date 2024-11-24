using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Fusion.XRShared;
using Fusion;
using Fusion.XR.Shared;
using System;
public class NetworkLabInteractable : NetworkBehaviour
{
    public NetworkTransform networkTransform;
    [HideInInspector]
    [Networked]
    public int OwnerID { get; set; } = -1;
    [HideInInspector]
    [Networked]
    public PourData currentPourData { get; set; }
    [HideInInspector]
    [Networked]
    public AbsorbData currentAbsorbData { get; set; }
    private bool isTakingAuthority = false;
    public LabInteractable labInteractable;
    ChangeDetector labChangeDetector;
    void Awake()
    {
        networkTransform = GetComponent<NetworkTransform>();
    }
    public override void Spawned()
    {
        base.Spawned();
        labChangeDetector = GetChangeDetector(ChangeDetector.Source.SnapshotFrom);
    }

    public override void FixedUpdateNetwork()
    {
        int newOwner = -1;
        if (TryDetectChange(labChangeDetector, nameof(OwnerID), out newOwner))
        {
            labInteractable.currentOwnerID = newOwner;
        }

    }

    public override void Render()
    {
        PourData newPour;
        AbsorbData newAbsorb;
        if (!Object.HasStateAuthority && TryDetectChange(labChangeDetector, nameof(currentPourData), out newPour))
        {
            labInteractable.LocalPour(newPour);
        }
        if (!Object.HasStateAuthority && TryDetectChange(labChangeDetector, nameof(currentAbsorbData), out newAbsorb))
        {
            labInteractable.LocalAbsorb(newAbsorb);
        }
    }
    public async void LocalGrab(int newOwner)
    {
        isTakingAuthority = true;
        await Object.WaitForStateAuthority();
        isTakingAuthority = false;
        OwnerID = newOwner;
    }

    public void LocalUngrab()
    {
        OwnerID = -1;
    }


    bool TryDetectChange<T>(ChangeDetector changeDetector, string variableName, out T newValue) where T : unmanaged
    {
        newValue = default;
        foreach (var changedNetworkedVarName in changeDetector.DetectChanges(this, out var previous, out var current))
        {
            if (changedNetworkedVarName == variableName)
            {
                var reader = GetPropertyReader<T>(changedNetworkedVarName);
                newValue = reader.Read(current);
                return true;
            }
        }
        return false;
    }
}
