using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;
public class NetworkHand : MonoBehaviour
{
    [SerializeField] CoherenceSync sync;
    [SerializeField] MeshRenderer mesh;
    void Start()
    {
        if(sync.HasStateAuthority){
            mesh.enabled = false;
        }
    }
}
