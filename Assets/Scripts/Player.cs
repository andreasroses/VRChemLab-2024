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
    [SerializeField] private float pourCooldown = 0.4f;
    private float pourTimer = 0f;
    private LiquidInteractable currLiquidHolding;
    private LiquidInteractable currTargetContainer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currLiquidHolding != null && checkForContainer(out LiquidInteractable container)){
            bool shouldPour = false;

            if(currLiquidHolding.isSingleDropper){
                if(pourAction.action.WasPressedThisFrame()){
                    shouldPour = true;
                }
            }
            else if(pourAction.action.IsPressed()){
                if(pourTimer <= 0){
                    shouldPour = true;
                    pourTimer = pourCooldown;
                }
            }
            if(shouldPour){
                currLiquidHolding.PourLiquid(container);
            }
        }

        if(pourTimer > 0){
            pourTimer -= Time.deltaTime;
        }

    }

    public void SelectInteract(SelectEnterEventArgs args){
        if(currLiquidHolding == null){
            currLiquidHolding = args.interactableObject.transform.GetComponent<LiquidInteractable>()?.SelectInteractable();
        }
    }

    public void Deselect(){
        if(currLiquidHolding != null){
            currLiquidHolding = null;
        }
    }

    private bool checkForContainer(out LiquidInteractable foundContainer){
        foundContainer = null;
        Collider[] hitColliders = Physics.OverlapSphere(interactController.position, interactRadius, containersLayer);
        foreach(Collider c in hitColliders){
            if(c.gameObject != currLiquidHolding.gameObject){
                foundContainer = c.gameObject.GetComponent<LiquidInteractable>();
                return true;
            }
        }
        return false;
    }
}
