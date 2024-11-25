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
    [SerializeField] protected Renderer liquidRend;
    public float pourRate;
    [SerializeField] protected float pourSpeed;
    [SerializeField] protected float absorbSpeed;

    [Header("Pour Effect")]
    [SerializeField] protected Component effect;
    [SerializeField] public PourDetector pd;

    [Header("HighlightEffect")]
    [SerializeField] private Renderer rend;
    [SerializeField] private int highlightMaterialIndex = 1;
    public bool isSingleDropper;
    private bool isPouring = false;
    private I_PourEffect pourEffect;

    //more highlight effect
    private Material highlightMaterial;
    private Color highlightColor;
    void Start()
    {
        pourEffect = (I_PourEffect)effect;
        
        highlightMaterial = rend.materials[highlightMaterialIndex];
        highlightColor = highlightMaterial.GetColor("_BaseColor");
    }

    void Update()
    {
        if (!isSingleDropper)
        {
            if (pd.endPour || !isPouring)
            {
                StopPour();
            }
        }
    }
    public void InitializePourEffect<T>(T component)
    {
        pourEffect.Initialize(component);
    }


    #region Selection
    public LabContainer SelectLabContainer(){
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
    #endregion
    
    #region Pouring Visuals
    [Command]
    public virtual void PourLiquid()
    {
        if (isPouring) return;

        float currFill = liquidRend.material.GetFloat("_fill");
        if (currFill >= -1 + pourRate)
        {
            pourEffect.DisplayPour();

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
        if (currFill < 1 - pourRate)
        {
            float endFill = currFill + addFill;
            LocalFillChange(currFill, endFill);
            sync.SendCommand<LabContainer>(nameof(LocalFillChange), MessageTarget.Other, currFill, endFill);
        }
    }

    public float GetMaterialFill()
    {
        return liquidRend.material.GetFloat("_fill");
    }

    public void StopPour()
    {
        pourEffect.EndPour();
    }

    private IEnumerator SmoothFill(float startFill, float endFill, float speed)
    {
        float time = 0;
        isPouring = true;
        while (time < 0.5)
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
