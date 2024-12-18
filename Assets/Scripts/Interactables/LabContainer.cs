using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;
public enum FlowType
{
    Single, Regular
}

public class LabContainer : MonoBehaviour
{
    [Header("Network")]
    [SerializeField] CoherenceSync sync;
    [Header("Fill Effect")]
    //have to set custom bottom and upper limits due to shader remapping
    [SerializeField] private float empty;
    [SerializeField] private float full;
    [SerializeField] private float refill;
    [SerializeField] protected Renderer liquidRend;
    public float pourRate;
    [SerializeField] protected float pourSpeed;
    [SerializeField] protected float absorbSpeed;

    [Header("Pour Effect")]
    [SerializeField] Transform pourOrigin;
    [SerializeField] public PourDetector pd;

    [Header("HighlightEffect")]
    [SerializeField] private Renderer rend;
    [SerializeField] private int highlightMaterialIndex = 1;
    public bool isSingleDropper;
    private bool isPouring = false;
    private SingleFlowEffect pourEffect;

    //more highlight effect
    private Material highlightMaterial;
    private Color highlightColor;
    void Start()
    {
        if(isSingleDropper){
            pourEffect = GameObject.FindGameObjectWithTag("DropperParticles").GetComponent<SingleFlowEffect>();
        }
        
        highlightMaterial = rend.materials[highlightMaterialIndex];
        highlightColor = highlightMaterial.GetColor("_BaseColor");
    }


    #region Selection
    public LabContainer SelectLabContainer(){
        PrepareEffect();
        return this;
    }

    #endregion

    #region  Network Visuals
    public void TryPour(){
        if(sync.HasStateAuthority){
            PourLiquid();
        }
        else{
            sync.SendCommand<LabContainer>(nameof(PourLiquid), MessageTarget.AuthorityOnly);
        }
    }

    public void TryAbsorb(float addFill){
        if(sync.HasStateAuthority){
            AbsorbLiquid(addFill);
        }
        else{
            sync.SendCommand<LabContainer>(nameof(AbsorbLiquid), MessageTarget.AuthorityOnly, addFill);
        }
    }

    public void TryRefill(){
        Refill();
        sync.SendCommand<LabContainer>(nameof(Refill), MessageTarget.Other);
    }
    
    private void PrepareEffect(){
        if(isSingleDropper && !sync.HasStateAuthority){
            pourEffect.PrefetchAuthority();
        }
    }
    #endregion
    
    #region Pouring Visuals
    [Command]
    public virtual void PourLiquid()
    {
        if (isPouring) return;

        float currFill = liquidRend.material.GetFloat("_fill");
        if (currFill > empty)
        {
            if(isSingleDropper){
                pourEffect.DisplayPour(pourOrigin.position);
            }

            float endFill = currFill - pourRate;
            LocalFillChange(currFill, endFill);
            
            sync.SendCommand<LabContainer>(nameof(LocalFillChange), MessageTarget.Other, currFill, endFill);
        }
    }
    [Command]
    public virtual void AbsorbLiquid(float addFill)
    {
        if (isPouring) return;
        float currFill = liquidRend.material.GetFloat("_fill");
        if (currFill < full)
        {
            float endFill = currFill + addFill;
            LocalFillChange(currFill, endFill);
            sync.SendCommand<LabContainer>(nameof(LocalFillChange), MessageTarget.Other, currFill, endFill);
        }
    }

    [Command]
    public void Refill(){
        liquidRend.material.SetFloat("_fill", refill);
    }
    public float GetMaterialFill()
    {
        return liquidRend.material.GetFloat("_fill");
    }

    private IEnumerator SmoothFill(float startFill, float endFill, float speed)
    {
        float time = 0;
        isPouring = true;
        while (time < 0.65)
        {
            time += Time.deltaTime * speed;
            
            float newFill = Mathf.Lerp(startFill, endFill, time);
            liquidRend.material.SetFloat("_fill", newFill);
            yield return null;
        }
        
        liquidRend.material.SetFloat("_fill", endFill);
        
        isPouring = false;
    }

    [Command]
    public void LocalFillChange(float startFill, float endFill)
    {
        if(!isPouring){
            StartCoroutine(SmoothFill(startFill, endFill, pourSpeed));
        }
    }

    #endregion

    #region Target Visuals

    public void ShowHighlight()
    {
        SetHighlightAlpha(1);
        sync.SendCommand<LabContainer>(nameof(SetHighlightAlpha), MessageTarget.Other, 1);
    }

    public void HideHighlight()
    {
        SetHighlightAlpha(0);
        sync.SendCommand<LabContainer>(nameof(SetHighlightAlpha), MessageTarget.Other, 0);
    }

    [Command]
    public void SetHighlightAlpha(int alpha)
    {
        Color newColor = highlightColor;
        newColor.a = alpha;
        
        highlightMaterial.SetColor("_BaseColor", newColor);
    }
    #endregion
    
    
}
