using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class UnderwaterArea : MonoBehaviour {

    public GameObject waterSplashFX;
    public AudioClip[] waterSplashSFX;
    public UnityEvent PlayerIsUnderwater;
    public UnityEvent PlayerIsAfloat;




    private void OnTriggerEnter(Collider other)
    {
        if (waterSplashSFX != null)
        {
            SoundManager.instance.PlaySingle(waterSplashSFX[Random.Range(0, waterSplashSFX.Length)]);
        }

        Instantiate(waterSplashFX, other.transform.position, Quaternion.identity);

        if (other.CompareTag("Player"))
        {
            PlayerIsUnderwater.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contacts[0]);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsAfloat.Invoke();
        }
    }
}
