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
    private LiquidInteractable currLiquidHolding;
    private LiquidInteractable currTargetContainer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currLiquidHolding != null && checkForContainer(out LiquidInteractable container)){
            bool shouldPour = currLiquidHolding.isSingleDropper
                            ? pourAction.action.WasPressedThisFrame()
                            : pourAction.action.IsPressed();

            if(shouldPour){
                currLiquidHolding.PourLiquid(container);
            }
        }

    }

    public void SelectInteract(SelectEnterEventArgs args){
        if(currLiquidHolding == null){
            currLiquidHolding = args.interactableObject.transform.GetComponent<LiquidInteractable>()?.SelectInteractable();
        }
    }

    private bool checkForContainer(out LiquidInteractable foundContainer){
        foundContainer = null;
        Collider[] hitColliders = Physics.OverlapSphere(interactController.position, interactRadius, containersLayer);
        if(hitColliders.Any()){
            foundContainer = hitColliders[0].gameObject.GetComponent<LiquidInteractable>();
            return true;
        }
        return false;
    }
}
