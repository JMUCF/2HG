using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip buttonAudio;
    public AudioClip pauseAudio;
    public AudioClip Ambience;


    public void PlayButton()
    {
        musicSource.clip = buttonAudio;
        musicSource.Play();
        SceneManager.LoadScene("Main Level");
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
