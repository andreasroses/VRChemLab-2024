using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabInteractable : MonoBehaviour
{
    [SerializeField] NetworkLabInteractable networkLabInteractable;
    [SerializeField] private LabContainer labContainer;
    [HideInInspector]
    public int currentOwnerID = -1;
    void Start()
    {
        labContainer.PourEvent.AddListener(UpdatePourData);
        labContainer.AbsorbEvent.AddListener(UpdateAbsorbData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LabContainer SelectInteractable(int playerID){
        currentOwnerID = playerID;
        networkLabInteractable.LocalGrab(playerID);
        return labContainer;        
    }

    public void DeselectInteractable(){
        currentOwnerID = -1;
        networkLabInteractable.LocalUngrab();
    }

    private void UpdatePourData(PourData pd){
        networkLabInteractable.currentPourData = pd;
    }

    private void UpdateAbsorbData(AbsorbData ad){
        networkLabInteractable.currentAbsorbData = ad;
    }
    
    public void LocalPour(PourData newPour){
        labContainer.LocalFillChange(newPour.startFill, newPour.endFill);
    }

    public void LocalAbsorb(AbsorbData newAbsorb){
        labContainer.LocalFillChange(newAbsorb.currFill, newAbsorb.endFill);
    }
}
