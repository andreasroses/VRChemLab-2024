using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFlowEffect : MonoBehaviour, I_PourEffect
{
    [SerializeField] private Transform pourOrigin;
    private ParticleSystem flowParticles;
    public void Initialize<T>(T component){
        if(component is ParticleSystem particles && flowParticles == null){
            flowParticles = particles;
        }
        else{
            Debug.LogError($"Invalid component type : {typeof(T)}. Expected ParticleSystem.");
        }
    }

    public void DisplayPour(){
        flowParticles.gameObject.SetActive(true);
        flowParticles.transform.position = pourOrigin.position;
        flowParticles.transform.SetParent(pourOrigin);
        flowParticles.Play();
    }

    public void EndPour(){
        flowParticles.gameObject.SetActive(false);
    }
}
