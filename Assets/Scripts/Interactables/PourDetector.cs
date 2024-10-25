using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    [SerializeField] private int pourThreshold = 45;
    [System.NonSerialized]public bool isPouring = false;

    void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if(isPouring != pourCheck){
            isPouring = pourCheck;
        }
    }

    private float CalculatePourAngle(){
        return transform.forward.y * Mathf.Rad2Deg;
    }
}
