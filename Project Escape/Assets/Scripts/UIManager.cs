using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager instance = null;
    public GameObject pauseMenu;


    bool isPaused;


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
        if (Input.GetKeyDown(KeyCode.Escape) && LevelManager.instance.GetActiveScene().name != "MainMenu" && LevelManager.instance.GetActiveScene().name != "Credits")
        {
            if (isPaused)
            {
                DeactivatePauseMenu();
            }
            else
            {
                ActivatePauseMenu();
            }

        }

    }

    public void ActivatePauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;

    }

    public void DeactivatePauseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;

    }

   
}
