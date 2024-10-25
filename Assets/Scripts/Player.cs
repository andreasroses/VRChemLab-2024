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
    [Header("Flow References")]
    [SerializeField] private ParticleSystem singleFlow;
    [SerializeField] private LineRenderer regularFlow;
    private float pourTimer = 0f;
    private bool isFlowing;
    private LiquidInteractable currLiquidHolding;
    private LiquidInteractable currTargetContainer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pourTimer > 0){
            pourTimer -= Time.deltaTime;
        }

        LiquidInteractable container;
        if(currLiquidHolding == null || !checkForContainer(out container)){
            currTargetContainer?.HideOutline();
            return;
        }

        if(currTargetContainer != container){
            currTargetContainer?.HideOutline();
            currTargetContainer = container;
        }

        bool shouldPour = currLiquidHolding.isSingleDropper
            ? pourAction.action.WasPressedThisFrame()
            : currLiquidHolding.pd.isPouring && pourTimer <= 0;

        if(shouldPour){
            currLiquidHolding.PourLiquid(container);
            if(!currLiquidHolding.isSingleDropper){
                pourTimer = pourCooldown;
            }
        }
        else{
            currLiquidHolding.StopPour();
            currTargetContainer = null;
        }
    }

    public void SelectInteract(SelectEnterEventArgs args){
        if(currLiquidHolding == null){
            currLiquidHolding = args.interactableObject.transform.GetComponent<LiquidInteractable>()?.SelectInteractable();
            if(currLiquidHolding.isSingleDropper){
                currLiquidHolding.InitializePourEffect(singleFlow);
            }
            else{
                currLiquidHolding.InitializePourEffect(regularFlow);
            }
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
