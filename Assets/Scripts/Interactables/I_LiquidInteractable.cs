using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_LiquidInteractable
{
    public I_LiquidInteractable SelectInteractable();

    public void PourLiquid(I_LiquidInteractable container);

    public void AbsorbLiquid(float addFill);
}
