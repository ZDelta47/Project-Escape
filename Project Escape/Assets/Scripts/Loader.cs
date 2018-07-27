using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject levelManager;
    public GameObject soundManager;
    public GameObject uiManager;

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (LevelManager.instance == null)
        {
            Instantiate(levelManager);
        }

        if (SoundManager.instance == null)
        {
            Instantiate(soundManager);
        }

        if (UIManager.instance == null)
        {
            Instantiate(uiManager);
        }
    }
}
