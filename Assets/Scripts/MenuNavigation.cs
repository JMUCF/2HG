using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip buttonAudio;
    public AudioClip pauseAudio;

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            musicSource.clip = buttonAudio;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "ControlsScreen")
        {
            musicSource.clip = buttonAudio;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "CreditsScreen")
        {
            musicSource.clip = buttonAudio;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            musicSource.clip = buttonAudio;
            musicSource.Play();
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlsScreen");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
