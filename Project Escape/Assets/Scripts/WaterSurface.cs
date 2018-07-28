using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurface : MonoBehaviour {

    public GameObject waterSplashFX;
    public AudioClip[] waterSplashInSFX;
    public AudioClip[] waterSplashOutSFX;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (waterSplashInSFX.Length != 0)
        {
            audioSource.PlayOneShot(waterSplashInSFX[Random.Range(0, waterSplashInSFX.Length)]);
        }

        GameObject instance = Instantiate(waterSplashFX, other.transform.position, Quaternion.identity, GarbageCollector.instance.transform);
        Destroy(instance, 3.0f);

    }

    private void OnTriggerExit(Collider other)
    {
        if (waterSplashOutSFX.Length != 0)
        {
            audioSource.PlayOneShot(waterSplashOutSFX[Random.Range(0, waterSplashOutSFX.Length)]);
        }
    }
}
