using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] Button resumeButton;
    [SerializeField] Button exitButton;
    public bool IsPaused => pauseMenuObject.activeSelf;

    void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        exitButton.onClick.AddListener(Exit);
        pauseMenuObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuObject.activeSelf)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
