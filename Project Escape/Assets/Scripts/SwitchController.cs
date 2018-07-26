using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour {

    public GameObject objectToActivate;
    public UnityEvent IsActivated;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objectToActivate)
        {
            IsActivated.Invoke();
            Debug.Log("Switch Activated");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == objectToActivate)
        {
            IsActivated.Invoke();
            Debug.Log("Switch Deactivated");
        }
    }
}
