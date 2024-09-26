using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour, I_LiquidInteractable
{
    [SerializeField] private Renderer rend;
    [SerializeField] private float pourRate;
    public I_LiquidInteractable SelectInteractable(){
        return this;
    }

    public void PourLiquid(I_LiquidInteractable container){
        float currFill = rend.material.GetFloat("_fill");
        rend.material.SetFloat("_fill", currFill - pourRate);
        container.AbsorbLiquid(pourRate);
    }

    public void AbsorbLiquid(float addFill){
        float currFill = rend.material.GetFloat("_fill");
        rend.material.SetFloat("_fill", currFill + addFill);
    }
}
