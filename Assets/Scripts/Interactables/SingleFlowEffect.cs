using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;
public class SingleFlowEffect : MonoBehaviour
{
    [SerializeField] private CoherenceSync sync;
    [SerializeField] private ParticleSystem flowParticles;

    [Command]
    public void DisplayPour(Vector3 pourOrigin){
        if(sync.HasStateAuthority){
            transform.position = pourOrigin;
            sync.SendCommand<SingleFlowEffect>(nameof(DisplayPour), MessageTarget.Other, pourOrigin);
        }
        
        flowParticles.Play();
    }

    public void PrefetchAuthority(){
        sync.RequestAuthority(AuthorityType.Full);
    }
}
