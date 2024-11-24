using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class Player : MonoBehaviour
{
    public int ID = 1;
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
    private LabContainer heldContainer;
    private LabContainer targetContainer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pourTimer > 0){
            pourTimer -= Time.deltaTime;
        }

        LabContainer container;
        if(heldContainer == null){
            return;
        }
        if(checkForContainer(out container)){
            if(targetContainer != container){
                targetContainer?.HideOutline();
                targetContainer = container;
                targetContainer.HighlightOutline();
            }

            bool shouldPour = heldContainer.isSingleDropper
                ? pourAction.action.WasPressedThisFrame()
                : heldContainer.pd.isPouring && pourTimer <= 0;

            if(shouldPour){
                heldContainer.PourLiquid(container);
                if(!heldContainer.isSingleDropper){
                    pourTimer = pourCooldown;
                }
            }
        }
        else if(targetContainer != null){
            targetContainer.HideOutline();
        }
        
    }

    public void SelectInteract(SelectEnterEventArgs args){
        if(heldContainer == null){
            heldContainer = args.interactableObject.transform.GetComponent<LabInteractable>()?.SelectInteractable(ID);
            if(heldContainer.isSingleDropper){
                heldContainer.InitializePourEffect(singleFlow);
            }
            else{
                heldContainer.InitializePourEffect(regularFlow);
            }
        }
    }

    public void Deselect(SelectExitEventArgs args){
        if(heldContainer != null){
            if(targetContainer != null){
                targetContainer.HideOutline();
                targetContainer = null;
            }
            heldContainer = null;
            args.interactableObject.transform.GetComponent<LabInteractable>()?.DeselectInteractable();
        }
    }

    private bool checkForContainer(out LabContainer foundContainer){
        foundContainer = null;
        Collider[] hitColliders = Physics.OverlapSphere(interactController.position, interactRadius, containersLayer);
        foreach(Collider c in hitColliders){
            if(c.gameObject != heldContainer.gameObject){
                foundContainer = c.gameObject.GetComponent<LabContainer>();
                return true;
            }
        }
        return false;
    }
}
