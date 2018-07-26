using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour {

    public GameObject block;
    public int blockCount;
    public float transitionTime;

    public float deactivatedHeight;

    public enum BridgeState { ACTIVATED , DEACTIVATED };
    public BridgeState currentPosition;

    GameObject[] blocks;
    BridgeBlockController[] blockController;


    void Awake () 
    {
        blocks = new GameObject[blockCount];
        blockController = new BridgeBlockController[blockCount];
        BuildBridge();
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ActivateBridgeCoroutine());
            
        }

            
	}

    // Initialize bridge before start (depending on startPosition)
    void BuildBridge ()
    {

        Vector3 newPosition;

        for (int i = 0; i < blockCount; i++)
        {

            if (i == 0)
            {
                if (currentPosition == BridgeState.DEACTIVATED)
                {
                    newPosition = transform.position + transform.up * deactivatedHeight;
                }
                else
                {
                    newPosition = transform.position;
                } 
            }
            else
            {
                newPosition = blocks[i - 1].transform.position + transform.forward * block.transform.localScale.z;
            }

            blocks[i] = (GameObject)Instantiate(block, newPosition, transform.rotation, transform);

            blockController[i] = blocks[i].GetComponent<BridgeBlockController>();

            if (currentPosition == BridgeState.ACTIVATED)
            {
                blockController[i].currentPosition = BridgeBlockController.BlockState.ACTIVATED;
                blockController[i].activatedPosition = blocks[i].transform.position;
                blockController[i].deactivatedPosition = blocks[i].transform.position + transform.up * deactivatedHeight;
            }
            else
            {
                blockController[i].currentPosition = BridgeBlockController.BlockState.DEACTIVATED;
                blockController[i].activatedPosition = blocks[i].transform.position - transform.up * deactivatedHeight;
                blockController[i].deactivatedPosition = blocks[i].transform.position;
            }

        }

    }

    public void ActivateBridge()
    {

       StartCoroutine(ActivateBridgeCoroutine());

    }

    // Activate the whole bridge
    IEnumerator ActivateBridgeCoroutine()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blockController[i].ActivateBlock(transitionTime / blockCount);
            yield return new WaitForSeconds(0.5f);
        }

        if (currentPosition == BridgeState.ACTIVATED)
        {
            currentPosition = BridgeState.DEACTIVATED;
        }
        else
        {
            currentPosition = BridgeState.ACTIVATED;
        }

    }

    // Draw helping gizmos for placing bridge in game world
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, block.transform.localScale);
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

        Gizmos.matrix *= cubeTransform;

        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

        Gizmos.matrix = oldGizmosMatrix;
    }

}
