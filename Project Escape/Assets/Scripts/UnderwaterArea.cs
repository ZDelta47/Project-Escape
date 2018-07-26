using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class UnderwaterArea : MonoBehaviour {


    public AudioClip[] waterSplashSFX;
    public UnityEvent PlayerIsUnderwater;
    public UnityEvent PlayerIsAfloat;



    private void OnTriggerEnter(Collider other)
    {
        if (waterSplashSFX != null)
        {
            SoundManager.instance.PlaySingle(waterSplashSFX[Random.Range(0, waterSplashSFX.Length)]);
        }
        

        if (other.CompareTag("Player"))
        {
            PlayerIsUnderwater.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsAfloat.Invoke();
        }
    }
}
