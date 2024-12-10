using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class Player : MonoBehaviour
{
    [SerializeField] private InputActionProperty pourAction;
    [SerializeField] private InputActionProperty refillAction;
    [Header("Interaction Settings")]
    [SerializeField] private Transform leftController;
    [SerializeField] private Transform rightController;
    [SerializeField] private Transform interactController;
    [SerializeField] private float interactRadius;
    [SerializeField] private LayerMask containersLayer;
    [SerializeField] private float pourCooldown = 0.4f;

    private float pourTimer = 0f;
    private LabContainer heldContainer;
    private LabContainer targetContainer;

    void Start()
    {
        interactController = rightController;

        refillAction.action.performed += context => OnRefill(context);
    }

    void Update()
    {
        if (pourTimer > 0)
        {
            pourTimer -= Time.deltaTime;
        }

        LabContainer container;
        if (heldContainer == null)
        {
            return;
        }
        if (checkForContainer(out container))
        {

            if (targetContainer != null && targetContainer != container)
            {
                targetContainer.HideHighlight();
                container.ShowHighlight();
            }
            else if(targetContainer == null)
            {
                container.ShowHighlight();
            }
            
            targetContainer = container;

            bool shouldPour = heldContainer.isSingleDropper
                ? pourAction.action.WasPressedThisFrame()
                : heldContainer.pd.isPouring && pourTimer <= 0;

            if (shouldPour)
            {
                heldContainer.TryPour();
                targetContainer.TryAbsorb(heldContainer.pourRate);
                if (!heldContainer.isSingleDropper)
                {
                    pourTimer = pourCooldown;
                }
            }
        }
        else if (targetContainer != null)
        {
            targetContainer.HideHighlight();
            targetContainer = null;
        }

    }

    public void SelectInteract(SelectEnterEventArgs args)
    {
        if (heldContainer == null)
        {
            heldContainer = args.interactableObject.transform.GetComponent<LabContainer>()?.SelectLabContainer();
        }

        if (args.interactorObject.transform.gameObject.CompareTag("LeftInteractor"))
        {
            interactController = leftController;
        }
        else
        {
            interactController = rightController;
        }
    }

    public void Deselect(SelectExitEventArgs args)
    {
        if (heldContainer != null)
        {
            if (targetContainer != null)
            {
                targetContainer.HideHighlight();
                targetContainer = null;
            }
            heldContainer = null;
        }
    }

    private void OnRefill(InputAction.CallbackContext context)
    {
        if (heldContainer != null)
        {
            heldContainer.TryRefill();
        }
    }
    
    private bool checkForContainer(out LabContainer foundContainer)
    {
        foundContainer = null;
        Collider[] hitColliders = Physics.OverlapSphere(interactController.position, interactRadius, containersLayer);

        float closestDistance = float.MaxValue;
        LabContainer closestContainer = null;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Collider c = hitColliders[i];

            if (c.gameObject == heldContainer.gameObject)
                continue;

            LabContainer container = c.GetComponent<LabContainer>();
            if (container != null && !container.isSingleDropper)
            {
                float distance = Vector3.Distance(interactController.position, c.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestContainer = container;
                }
            }
        }

        if (closestContainer != null)
        {
            foundContainer = closestContainer;
            return true;
        }

        return false;
    }
}
