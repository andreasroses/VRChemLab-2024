using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    //point at end of pour stream
    private Vector3 FindEndPoint(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    private void MovePoint(int index, Vector3 targetPos){
        lineRenderer.SetPosition(index, targetPos);
    }
}
