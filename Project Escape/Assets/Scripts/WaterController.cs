using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterController : MonoBehaviour {

    public GameObject player;

    [Range(0.0f, 5.0f)]
    public float currentWaterLevel;

    [Header("Animation Settings")]
    public bool animateWaterLevel = false;
    public float timeInSec;
    public float maxWaterLevel;
    public float minWaterLevel;


	void Start () 
    {
        transform.position = new Vector3(transform.position.x, currentWaterLevel, transform.position.z);
	}
	
	void Update () 
    {
        if (animateWaterLevel)
        {
            IncreaseWaterLevelByTime();
        }
        else 
        {
            transform.position = new Vector3(transform.position.x, currentWaterLevel, transform.position.z);
        }

    }

    void IncreaseWaterLevelByTime ()
    {
        currentWaterLevel = transform.position.y;

        if (currentWaterLevel < maxWaterLevel)
        {
            float speed = (maxWaterLevel - minWaterLevel) / timeInSec;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, maxWaterLevel, transform.position.z);
        }
    }
}
