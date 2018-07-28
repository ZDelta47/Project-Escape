using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class CheckCollision : MonoBehaviour {

    public bool isColliding;
    public bool isUsed;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Water"))
        {
            isColliding = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
