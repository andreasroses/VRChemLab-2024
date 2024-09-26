using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class Player : MonoBehaviour
{
    [SerializeField] private InputActionProperty pourAction;
    [Header("Interaction Settings")]
    [SerializeField] private Transform interactController;
    [SerializeField] private float interactRadius;
    [SerializeField] private LayerMask containersLayer;
    private I_LiquidInteractable currLiquidHolding;
    private I_LiquidInteractable currTargetContainer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pourAction.action.WasPressedThisFrame()){
            I_LiquidInteractable container;
            if(checkForContainer(out container) && currLiquidHolding != null){
                currLiquidHolding.PourLiquid(container);
            }
        }
    }

    public void SelectInteract(SelectEnterEventArgs args){
        if(currLiquidHolding == null){
            currLiquidHolding = args.interactableObject.transform.GetComponent<I_LiquidInteractable>()?.SelectInteractable();
        }
    }

    private bool checkForContainer(out I_LiquidInteractable foundContainer){
        foundContainer = null;
        Collider[] hitColliders = Physics.OverlapSphere(interactController.position, interactRadius, containersLayer);
        if(hitColliders.Any()){
            foundContainer = hitColliders[0].gameObject.GetComponent<I_LiquidInteractable>();
            return true;
        }
        return false;
    }
}
