using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject door;
    public Transform open;
    public Transform closed;
    public AudioClip openingSFX;

    public float transitionTime = 3.0f;

    public enum DoorState { OPENING, CLOSING };

    public DoorState nextAction;



    IEnumerator currentMoveDoorCoroutine;

    private void Awake()
    {
        if (door.transform.position == open.position)
            nextAction = DoorState.CLOSING;
        else
            nextAction = DoorState.OPENING;
    }

    public void ActivateDoor()
    {
        if (currentMoveDoorCoroutine != null)
        {
            StopCoroutine(currentMoveDoorCoroutine);
        }

        // Open Door
        if (nextAction == DoorState.OPENING)
        {
            currentMoveDoorCoroutine = MoveDoor(open.position);
            StartCoroutine(currentMoveDoorCoroutine);
            nextAction = DoorState.CLOSING;
            SoundManager.instance.PlaySingle(openingSFX);
        }
        // Close Door
        else if (nextAction == DoorState.CLOSING)
        {
            currentMoveDoorCoroutine = MoveDoor(closed.position);
            StartCoroutine(currentMoveDoorCoroutine);
            nextAction = DoorState.OPENING;
            SoundManager.instance.PlaySingle(openingSFX);

        }

    }

    IEnumerator MoveDoor(Vector3 destination)
    {

        float distance = Vector3.Distance(destination, door.transform.position);
        float step = distance / transitionTime;

        while (door.transform.position != destination)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, destination, step * Time.deltaTime);
            yield return null;
        }

    }


}
