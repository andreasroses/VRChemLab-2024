using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabInteractable : MonoBehaviour
{
    public Vector3 localPositionOffset;
    public Quaternion localRotationOffset;
    [SerializeField] private LabContainer labContainer;
    public int currentOwnerID = -1;
    [HideInInspector]
    //public NetworkInteractable networkInteractable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LabContainer SelectInteractable(int playerID){
        currentOwnerID = playerID;
        return labContainer;
    }
}
