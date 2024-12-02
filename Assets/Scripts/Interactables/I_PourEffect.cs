using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_PourEffect
{
    void DisplayPour(Vector3 pourOrigin);

    void EndPour();

    public void PrefetchAuthority();
}
