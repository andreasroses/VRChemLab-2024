using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Fusion.XRShared;
using Fusion;
using Fusion.XR.Shared;
public class NetworkLabInteractable : NetworkBehaviour
{
    public NetworkTransform networkTransform;
    [Networked]
    public int OwnerID { get; set; }
    [Networked]
    public Vector3 LocalPositionOffset { get; set; }
    [Networked]
    public Quaternion LocalRotationOffset { get; set; }
    public bool isTakingAuthority = false;
    [HideInInspector]
    public LabInteractable labInteractable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async virtual void LocalGrab()
        {
            // Ask and wait to receive the stateAuthority to move the object
            isTakingAuthority = true;
            await Object.WaitForStateAuthority();
            isTakingAuthority = false;

            // We waited to have the state authority before setting Networked vars
            LocalPositionOffset = labInteractable.localPositionOffset;
            LocalRotationOffset = labInteractable.localRotationOffset;

            if(labInteractable.currentOwnerID < 0)
            {
                // The labInteractable has already been ungrabbed
                return;
            }
            // Update the CurrentGrabber in order to start following position in the FixedUpdateNetwork
            //CurrentGrabber = labInteractable.currentGrabber.networkGrabber;
        }
}
