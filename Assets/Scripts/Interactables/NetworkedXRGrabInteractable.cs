using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;

public class NetworkedXRGrabInteractable : XRGrabInteractable
{
    [SerializeField] CoherenceSync sync;
    [Sync, HideInInspector]
    public bool isGrabbed = false;
    private bool isGrabbing = false;
    private SelectEnterEventArgs latestSelectArgs;

    protected override void OnEnable(){
        base.OnEnable();
        sync.OnAuthorityRequested += OnAuthorityRequested;
        sync.OnStateAuthority.AddListener(OnStateAuthority);
    }
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        latestSelectArgs = args;
        if (!sync.HasStateAuthority)
        {
            sync.RequestAuthority(AuthorityType.Full);
            isGrabbing = true;
        }
        else
        {
            isGrabbed = true;
            base.OnSelectEntering(args);
        }
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);

        isGrabbed = false;
    }

    private bool OnAuthorityRequested(ClientID requesterid, AuthorityType authoritytype, CoherenceSync sync)
    {
        return !isGrabbed && !isGrabbing;
    }

    private void OnStateAuthority(){
        if(isGrabbing){
            isGrabbing = false;
            ConfirmGrab();
        }
    }

    private void ConfirmGrab(){
        isGrabbed = true;
        base.OnSelectEntering(latestSelectArgs);
    }
}
