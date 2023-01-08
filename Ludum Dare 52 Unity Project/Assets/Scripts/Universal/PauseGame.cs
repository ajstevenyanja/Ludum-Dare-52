using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseGame : MonoBehaviour
{
    [SerializeField] private KeyCode pauseButton = KeyCode.Escape;
    [SerializeField] private GameObject onPauseUI;

    bool isPaused;

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(pauseButton))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                if (onPauseUI != null)
                {
                    onPauseUI.SetActive(true);
                }
            }
            else
            {
                Time.timeScale = 1;
                if (onPauseUI != null)
                {
                    onPauseUI.SetActive(false);
                }
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        if (onPauseUI != null)
        {
            onPauseUI.SetActive(false);
        }
    }

    public void PauseTheGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        if (onPauseUI != null)
        {
            onPauseUI.SetActive(true);
        }
    }
}

