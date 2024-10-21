using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    private float animSpeed = 1.75f;
    //point at end of pour stream
    private Vector3 findEndPoint(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    private void movePoint(int index, Vector3 targetPos){
        lineRenderer.SetPosition(index, targetPos);
    }
    private void animateToPosition(int index, Vector3 targetPos){
        Vector3 currPos = lineRenderer.GetPosition(index);
        Vector3 newPos = Vector3.MoveTowards(currPos, targetPos, Time.deltaTime * animSpeed);
        lineRenderer.SetPosition(index, newPos);
    }
    private bool hasReachedPosition(int index, Vector3 targetPos){
        Vector3 currPos = lineRenderer.GetPosition(index);
        return currPos == targetPos;
    }
}
