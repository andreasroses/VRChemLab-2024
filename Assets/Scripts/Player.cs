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
    [Header("Flow Settings")]
    [SerializeField] private GameObject singleFlow;
    [SerializeField] private GameObject regularFlow;
    [SerializeField] private float verticalOffset = 10;
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
        if(currLiquidHolding != null && checkForContainer(out LiquidInteractable container)){
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
                if(!isFlowing){
                    activateFlowParticles(currLiquidHolding.isSingleDropper);
                    isFlowing = true;
                }
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
            isFlowing = false;
            singleFlow.SetActive(false);
            regularFlow.SetActive(false);
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

    private void activateFlowParticles(bool isSingle){
        GameObject flow;
        if(isSingle){
            flow = singleFlow;
        }else{
            flow = regularFlow;
        }
        flow.transform.position = currLiquidHolding.transform.position - new Vector3(0,verticalOffset, 0);
        flow.SetActive(true);
    }
}
