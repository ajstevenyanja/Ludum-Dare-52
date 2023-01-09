using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PauseGamePro : MonoBehaviour
{
    [SerializeField] private KeyCode pauseButton = KeyCode.Escape;
    [SerializeField] private GameObject onPauseUI;
    [SerializeField] UnityEvent OnPauseEnter;
    [SerializeField] UnityEvent OnPauseExit;

    bool isPaused;

    private void Start()
    {
        isPaused = false;
        onPauseUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(pauseButton))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseTheGame();
            }
        }
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked; // HARD CODED
        Cursor.visible = false; // HARD CODED

        OnPauseExit.Invoke();
        Time.timeScale = 1;
        if (onPauseUI != null)
        {
            onPauseUI.SetActive(false);
        }

        isPaused = false;
    }

    public void PauseTheGame()
    {
        Cursor.lockState = CursorLockMode.None; // HARD CODED
        Cursor.visible = true; // HARD CODED

        OnPauseEnter.Invoke();
        Time.timeScale = 0;
        if (onPauseUI != null)
        {
            onPauseUI.SetActive(true);
        }

        isPaused = true;
    }

    public void PauseGameNoUI()
    {
        Cursor.lockState = CursorLockMode.None; // HARD CODED
        Cursor.visible = true; // HARD CODED

        OnPauseEnter.Invoke();
        Time.timeScale = 0;

        isPaused = true;
    }
}

