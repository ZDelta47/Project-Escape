using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBlockController : MonoBehaviour {

    public enum BlockState { ACTIVATED, DEACTIVATED };
    [HideInInspector] public BlockState currentPosition;

    [HideInInspector] public Vector3 activatedPosition;
    [HideInInspector] public Vector3 deactivatedPosition;

    IEnumerator currentCoroutine;

    // Decide if a block needs to be activated or deactivated and set its desired height accordingly
    public void ActivateBlock(float time)
    {
        {
            Vector3 endPos;

            if (currentPosition == BlockState.ACTIVATED)
            {
                endPos = deactivatedPosition;
                currentPosition = BlockState.DEACTIVATED;
            }
            else
            {
                endPos = activatedPosition;
                currentPosition = BlockState.ACTIVATED;
            }

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }


            currentCoroutine = SetBlockHeight(endPos, time);
            StartCoroutine(currentCoroutine);
        }
    }

    // Set block height
    IEnumerator SetBlockHeight(Vector3 endPos, float time)
    {
        float distance = Vector3.Distance(endPos, transform.position);
        float step = distance / time;

        while (transform.position != endPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, step * Time.deltaTime);
            yield return null;
        }
    }
}


