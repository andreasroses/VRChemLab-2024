using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    [SerializeField] private int pourThreshold = 45;
    [System.NonSerialized]public bool isPouring = false;
    [System.NonSerialized]public bool endPour = false;
    void Update()
    {
        bool pourCheck = CalculatePourAngle() > pourThreshold;

        if(isPouring != pourCheck){
            isPouring = pourCheck;
            if(!pourCheck){
                endPour = true;
            }
            else{
                endPour = false;
            }
        }
    }

    private float CalculatePourAngle(){
        // Debug.Log("Pour Angle: " + transform.forward.y * Mathf.Rad2Deg);
        return Vector3.Angle(transform.up, Vector3.up);
    }
}
