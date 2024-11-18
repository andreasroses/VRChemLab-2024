using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FlowType{
    Single, Regular
}
public class LabContainer : MonoBehaviour
{
    [Header("Fill Effect")]
    [SerializeField] protected Renderer liquidRend;
    [SerializeField] protected float pourRate;
    [SerializeField] protected float pourSpeed;
    [SerializeField] protected float absorbSpeed;

    [Header("Pour Effect")]
    [SerializeField] protected Component effect;
    [SerializeField] public PourDetector pd;
    
    [Header("OutlineEffect")]
    [SerializeField] private Renderer rend;
    [SerializeField] private int outlineMaterialIndex = 1;
    public bool isSingleDropper;
    private bool isPouring = false;
    private I_PourEffect pourEffect;
    
    //more outline effect
    private Material outlineMaterial;
    private Color outlineColor;
    void Start(){
        pourEffect = (I_PourEffect) effect;
        outlineMaterial = rend.materials[outlineMaterialIndex];
        outlineColor = outlineMaterial.GetColor("_OutlineColor");
    }

    void Update(){
        if(!isSingleDropper){
            if(pd.endPour){
                StopPour();
            }
        }
    }
    public void InitializePourEffect<T>(T component){
        pourEffect.Initialize(component);
    }
    public virtual void PourLiquid(LabContainer container){
        if(isPouring) return;
        float currFill = liquidRend.material.GetFloat("_fill");
        if(currFill >= -1 + pourRate){
            isPouring = true;
            pourEffect.DisplayPour();
            StartCoroutine(SmoothFill(currFill, currFill - pourRate, pourSpeed));
            container.AbsorbLiquid(pourRate);
        }
    }

    public virtual void AbsorbLiquid(float addFill){
        if(isPouring) return;
        float currFill = liquidRend.material.GetFloat("_fill");
        if(currFill < 1 - pourRate){
            isPouring = true;
            StartCoroutine(SmoothFill(currFill, currFill + addFill, absorbSpeed));
        }
    }

    public void StopPour(){
        pourEffect.EndPour();
    }

    private IEnumerator SmoothFill(float startFill, float endFill, float speed){
        float time = 0;
        while(time < 0.5){
            time += Time.deltaTime * speed;
            float newFill = Mathf.Lerp(startFill, endFill, time);
            liquidRend.material.SetFloat("_fill", newFill);
            yield return null;
        }
        liquidRend.material.SetFloat("_fill", endFill);
        isPouring = false;
    }

    public void HighlightOutline(){
        SetOutlineAlpha(1);
    }

    public void HideOutline(){
        SetOutlineAlpha(0);
    }

    private void SetOutlineAlpha(float alpha)
    {
        outlineMaterial.SetColor("_OutlineColor", new Color(outlineColor.r, outlineColor.g, outlineColor.b, alpha));
    }
}