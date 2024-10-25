using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularFlowEffect : MonoBehaviour, I_PourEffect
{
    [SerializeField] private Transform pourOrigin;
    private LineRenderer flowLine;
    private float animSpeed = 1.75f;
    private Vector3 targetPosition;
    private Coroutine pourRoutine;
    public void Initialize<T>(T component)
    {
        if(component is LineRenderer line && flowLine == null){
            flowLine = line;
        }
        else{
            Debug.LogError($"Invalid component type : {typeof(T)}. Expected LineRenderer.");
        }
    }
    
    public void DisplayPour()
    {
        flowLine.gameObject.SetActive(true);
        pourRoutine = StartCoroutine(BeginPour());
    }

    public void EndPour()
    {
        StopCoroutine(pourRoutine);
        StartCoroutine(PourEnd());
    }

    private IEnumerator BeginPour()
    {
        while(gameObject.activeSelf){
            targetPosition = findEndPoint();

            movePoint(0, pourOrigin.position);
            animateToPosition(1, targetPosition);

            yield return null;
        }
    }

    private IEnumerator PourEnd()
    {
        while(!hasReachedPosition(0, targetPosition)){
            animateToPosition(0, targetPosition);
            animateToPosition(1, targetPosition);

            yield return null;
        }
        flowLine.gameObject.SetActive(false);
    }

    //point at end of pour stream
    private Vector3 findEndPoint(){
        RaycastHit hit;
        Ray ray = new Ray(pourOrigin.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    private void movePoint(int index, Vector3 targetPos){
        flowLine.SetPosition(index, targetPos);
    }
    private void animateToPosition(int index, Vector3 targetPos){
        Vector3 currPos = flowLine.GetPosition(index);
        Vector3 newPos = Vector3.MoveTowards(currPos, targetPos, Time.deltaTime * animSpeed);
        flowLine.SetPosition(index, newPos);
    }
    private bool hasReachedPosition(int index, Vector3 targetPos){
        Vector3 currPos = flowLine.GetPosition(index);
        return currPos == targetPos;
    }
}
