using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip buttonAudio;
    public AudioClip pauseAudio;
    public static Audio instance;

    private void Awake()
    {
       if (instance != null)
        {
            Destroy(gameObject);
        }
       else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

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
}
