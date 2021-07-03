using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public GameObject music;
    public GameObject sound;

    public GameObject music_Off;
    public GameObject sound_Off;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            music.SetActive(false);
            music_Off.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Sound", 1) == 0)
        {
            sound.SetActive(false);
            music_Off.SetActive(true);
        }
            
    }
}
