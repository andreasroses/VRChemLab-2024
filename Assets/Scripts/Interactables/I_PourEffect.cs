using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_PourEffect
{
    void Initialize<T>(T component);
    void DisplayPour();
}
