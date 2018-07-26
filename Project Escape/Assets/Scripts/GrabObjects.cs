using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour {
    
    public Transform firstPersonCharacter;
    public float distance;
    public float actionRadius;
    public LayerMask layerMask;
    public GameObject currentInteractable;
    public float floatingSpeed;
    public float throwForceMultiplier;

    Vector3 previousPosition;
    Vector3 currentPosition;

	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(firstPersonCharacter.position, firstPersonCharacter.forward, out hit, actionRadius, layerMask))
            {
                if (hit.transform.CompareTag("Grab"))
                {

                    ActivateInteractable(hit);
                }
            }
        }

        if (currentInteractable != null)
        {
            if (Input.GetMouseButton(0))
            {
                InteractablePositionAndRotation();
                
                if (currentInteractable.GetComponent<CheckCollision>().isColliding)
                {
                    DeactivateInteractable();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                DeactivateInteractable();
            }
        }
    }

    void ActivateInteractable (RaycastHit hit)
    {
        currentInteractable = hit.transform.gameObject;
        currentInteractable.GetComponent<CheckCollision>().isUsed = true;
        Rigidbody rb = currentInteractable.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    void InteractablePositionAndRotation()
    {
        previousPosition = currentInteractable.transform.position;

        // Handling position of currentInteractable
        Vector3 distanceVector = firstPersonCharacter.forward * distance;
        currentInteractable.transform.position = Vector3.Lerp(currentInteractable.transform.position, firstPersonCharacter.position + distanceVector, floatingSpeed * Time.deltaTime);

        // Handling rotation of currentInteractable
        Quaternion newRotation = Quaternion.LookRotation(-firstPersonCharacter.forward, Vector3.up);
        currentInteractable.transform.rotation = Quaternion.Lerp(currentInteractable.transform.rotation, newRotation, floatingSpeed * Time.deltaTime);

    }

    void DeactivateInteractable ()
    {
        Vector3 forceDirection = currentInteractable.transform.position - previousPosition;

        currentInteractable.GetComponent<CheckCollision>().isUsed = false;

        Rigidbody rb = currentInteractable.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(forceDirection * throwForceMultiplier, ForceMode.Impulse);

        currentInteractable = null;
    }
}
