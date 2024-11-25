using System;
using System.Collections;
using UnityEngine;
using Fusion;
using Fusion.XR.Shared;
using UnityEngine.Events;
public enum FlowType
{
    Single, Regular
}

public struct PourData : INetworkStruct
{
    public float startFill;
    public float endFill;
    public PourData(float startFill, float endFill)
    {
        this.startFill = startFill;
        this.endFill = endFill;

    }
}

public struct AbsorbData : INetworkStruct
{
    public float currFill;
    public float endFill;
    public AbsorbData(float currFill, float addFill)
    {
        this.currFill = currFill;
        endFill = currFill + addFill;
    }
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

    [HideInInspector]
    public UnityEvent<PourData> PourEvent;
    [HideInInspector]
    public UnityEvent<AbsorbData> AbsorbEvent;
    //more outline effect
    private Material outlineMaterial;
    private Color outlineColor;
    void Start()
    {
        pourEffect = (I_PourEffect)effect;
        outlineMaterial = rend.materials[outlineMaterialIndex];
        outlineColor = outlineMaterial.GetColor("_OutlineColor");
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
    public virtual void PourLiquid(LabContainer container)
    {
        if (isPouring) return;

        float currFill = liquidRend.material.GetFloat("_fill");
        if (currFill >= -1 + pourRate)
        {
            isPouring = true;
            
            PourData pourData = new PourData(currFill, currFill - pourRate);
            PourEvent?.Invoke(pourData);
            
            pourEffect.DisplayPour();
            StartCoroutine(SmoothFill(currFill, currFill - pourRate, pourSpeed));
            container.AbsorbLiquid(pourRate);
        }
    }

    public virtual void AbsorbLiquid(float addFill)
    {
        if (isPouring) return;
        float currFill = liquidRend.material.GetFloat("_fill");
        if (currFill < 1 - pourRate)
        {
            isPouring = true;
            
            AbsorbData absorbData = new AbsorbData(currFill, addFill);
            AbsorbEvent?.Invoke(absorbData);
            
            StartCoroutine(SmoothFill(currFill, currFill + addFill, absorbSpeed));
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

    public void HighlightOutline()
    {
        SetOutlineAlpha(1);
    }

    public void HideOutline()
    {
        SetOutlineAlpha(0);
    }

    public void LocalFillChange(float startFill, float endFill)
    {
        if(!isPouring){
            StartCoroutine(SmoothFill(startFill, endFill, pourSpeed));
        }
    }
    private void SetOutlineAlpha(float alpha)
    {
        outlineMaterial.SetColor("_OutlineColor", new Color(outlineColor.r, outlineColor.g, outlineColor.b, alpha));
    }
}
