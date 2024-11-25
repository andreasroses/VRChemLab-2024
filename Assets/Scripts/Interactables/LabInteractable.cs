using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabInteractable : MonoBehaviour
{
    [SerializeField] private LabContainer labContainer;
    [HideInInspector]
    public bool isGrabbed = false;

    public LabContainer SelectInteractable(){
        if(!isGrabbed){
            isGrabbed = true;
            return labContainer;  
        }
        return null;
    }

    public void DeselectInteractable(){
        isGrabbed = false;
    }
}
