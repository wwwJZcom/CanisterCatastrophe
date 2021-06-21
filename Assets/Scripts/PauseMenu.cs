using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public float TimePassed;

    void Start()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        TimePassed += Time.deltaTime;

        if (Input.GetKey(KeyCode.Escape))
        {
            if ((isPaused = false) && (TimePassed >= 0.5f))
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void Pause()
    {
        //Sets Pause menu UI as active, slows time down to 0 so its basically frozen, and changes isPaused to true since it is paused.
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.1f;
        isPaused = true;
        TimePassed = 0.0f;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        TimePassed = 0.0f;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
    }

}
