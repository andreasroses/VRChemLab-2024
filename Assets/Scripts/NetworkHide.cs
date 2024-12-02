using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;
public class NetworkHide : MonoBehaviour
{
    [SerializeField] CoherenceSync sync;
    [SerializeField] MeshRenderer[] meshes;
    void Start()
    {
        if(sync.HasStateAuthority){
            foreach(MeshRenderer m in meshes){
                m.enabled = false;
            }
        }
    }
}
