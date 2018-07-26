using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class CheckCollision : MonoBehaviour {

    public bool isColliding;
    public bool isUsed;

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
