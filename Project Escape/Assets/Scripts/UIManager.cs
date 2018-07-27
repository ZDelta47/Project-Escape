using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager instance = null;
    public GameObject pauseMenu;


    public bool isPaused;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

        }

        if (isPaused)
        {
            ActivatePauseMenu();

            if (Input.GetKeyDown(KeyCode.R))
            {
                LevelManager.instance.RestartScene();
                DeactivatePauseMenu();
                isPaused = false;
            }
        }
        else
        {
            DeactivatePauseMenu();
        }

    }

    void ActivatePauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

    }

    void DeactivatePauseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }
}
