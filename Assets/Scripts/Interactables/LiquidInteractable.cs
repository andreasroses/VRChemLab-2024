using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FlowType{
    Single, Regular
}
public class LiquidInteractable : MonoBehaviour
{
    [SerializeField] protected Renderer rend;
    [SerializeField] protected Transform pourOrigin;
    [SerializeField] protected float pourRate;
    [SerializeField] protected float pourSpeed;
    [SerializeField] protected float absorbSpeed;
    public bool isSingleDropper;
    private bool isPouring = false;
    private GameObject flow = null;
    public LiquidInteractable SelectInteractable(){
        return this;
    }

    public virtual void PourLiquid(LiquidInteractable container){
        if (isPouring) return;
        float currFill = rend.material.GetFloat("_fill");
        if(currFill >= -1 + pourRate){
            isPouring = true;
            StartCoroutine(SmoothFill(currFill, currFill - pourRate, pourSpeed));
            container.AbsorbLiquid(pourRate);
        }
    }

    public virtual void AbsorbLiquid(float addFill){
        if (isPouring) return;
        float currFill = rend.material.GetFloat("_fill");
        if(currFill < 1 - pourRate){
            isPouring = true;
            StartCoroutine(SmoothFill(currFill, currFill + addFill, absorbSpeed));
        }
    }

    private IEnumerator SmoothFill(float startFill, float endFill, float speed){
        float time = 0;
        while(time < 0.5){
            time += Time.deltaTime * speed;
            float newFill = Mathf.Lerp(startFill, endFill, time);
            rend.material.SetFloat("_fill", newFill);
            yield return null;
        }
        rend.material.SetFloat("_fill", endFill);
        isPouring = false;
    }

    public void PlaceParticlesAtFlowPoint(GameObject flow){
        flow.transform.position = pourOrigin.position;
        flow.SetActive(true);
        this.flow = flow;
    }
}
