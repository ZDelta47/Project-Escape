using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class UnderwaterArea : MonoBehaviour {

    public GameObject waterSplashFX;
    public AudioClip[] waterSplashInSFX;
    public AudioClip[] waterSplashOutSFX;

    AudioSource audioSource;

    public UnityEvent PlayerIsUnderwater;
    public UnityEvent PlayerIsAfloat;

    public float waterSurfaceHeight;

    private void Awake()
    {
        BoxCollider col = GetComponent<BoxCollider>();
        waterSurfaceHeight = transform.position.y + col.size.y / 2;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.transform.position.y > waterSurfaceHeight)
        {
            if (waterSplashInSFX.Length != 0)
            {
                audioSource.PlayOneShot(waterSplashInSFX[Random.Range(0, waterSplashInSFX.Length)]);
            }

            GameObject instance = Instantiate(waterSplashFX, other.transform.position, Quaternion.identity, GarbageCollector.instance.transform);
            Destroy(instance, 3.0f);
        }

        if (other.CompareTag("Player"))
        {
            PlayerIsUnderwater.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {

            if (waterSplashOutSFX.Length != 0)
            {
                audioSource.PlayOneShot(waterSplashOutSFX[Random.Range(0, waterSplashOutSFX.Length)]);
            }

        if (other.CompareTag("Player"))
        {
            PlayerIsAfloat.Invoke();
        }
    }
}
