using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public bool mouseLookEnabled;
    public AudioSource musicSource;
    public AudioClip buttonAudio;
    public AudioClip pauseAudio;
    public AudioClip Ambience;

    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                musicSource.clip = pauseAudio;
                musicSource.Play();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        musicSource.clip = Ambience;
        musicSource.Play();
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        musicSource.clip = Ambience;
        musicSource.Pause();
    }

    public void LoadControlsMenu()
    {
        SceneManager.LoadScene("ControlsScreen");
        Debug.Log("Loading Controls");
        musicSource.clip = buttonAudio;
        musicSource.Pause();
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu");
        musicSource.clip = buttonAudio;
        musicSource.Pause();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}