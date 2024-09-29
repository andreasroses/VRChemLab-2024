using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidInteractable : MonoBehaviour
{
    [SerializeField] protected Renderer rend;
    [SerializeField] protected float pourRate;
    public bool isSingleDropper;
    public LiquidInteractable SelectInteractable(){
        return this;
    }

    public virtual void PourLiquid(LiquidInteractable container){
        float currFill = rend.material.GetFloat("_fill");
        if(currFill >= -2 + pourRate){
            rend.material.SetFloat("_fill", currFill - pourRate);
            container.AbsorbLiquid(pourRate);
        }
    }

    public virtual void AbsorbLiquid(float addFill){
        float currFill = rend.material.GetFloat("_fill");
        if(currFill < 2 - pourRate){
            rend.material.SetFloat("_fill", currFill + addFill);
        }
    }
}
