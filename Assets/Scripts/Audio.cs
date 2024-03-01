using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip buttonAudio;
    public AudioClip pauseAudio;
    public AudioClip ambience;
    public static Audio instance;



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
            musicSource.clip = ambience;
            musicSource.Play();
        }
    }
}
