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
        transform.position = pourOrigin;
        flowParticles.Play();
        if(!sync.HasStateAuthority){
            sync.SendCommand<SingleFlowEffect>(nameof(DisplayPour), MessageTarget.AuthorityOnly, pourOrigin);
        }
        
    }
}
