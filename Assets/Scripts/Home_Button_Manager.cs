using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Home_Button_Manager : MonoBehaviour
{
    public GameObject Music_Off;
    public GameObject Sound_Off;
    public GameObject music;
    public GameObject sound;

    private bool IsSpent;

    public Text Star_Count_text;

    private void Start()
    {
        IsSpent = false;
        PlayerPrefs.SetInt("Player_Id", 0);
        //PlayerPrefs.SetInt("Star", 1000);
        Star_Count_text.text = PlayerPrefs.GetInt("Star", 0).ToString();
    }
    public void Play()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        SceneManager.LoadScene(1);
    }

    public void Close(GameObject Panel)
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        //Closing panel
        Panel.SetActive(false);
    }

    public void Open(GameObject Panel)
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        //open shop panel
        Panel.SetActive(true);
    }

    public void Music()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
            //Debug.Log(PlayerPrefs.GetInt("Music"));
            Music_Off.SetActive(true);
            music.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            //Debug.Log(PlayerPrefs.GetInt("Music"));
            Music_Off.SetActive(false);
            music.SetActive(true);
        }
    }

    public void Sound()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            //Debug.Log(PlayerPrefs.GetInt("Sound"));
            Sound_Off.SetActive(true);
            sound.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            //Debug.Log(PlayerPrefs.GetInt("Sound"));
            Sound_Off.SetActive(false);
            sound.SetActive(true);
        }
    }

    public void spend(int price)
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        int stars = PlayerPrefs.GetInt("Star", 0);
        Debug.Log(PlayerPrefs.GetInt("Star", 0));
        if (stars >= price && PlayerPrefs.GetInt("Player_Id", 0)==0)
        {
            stars = stars - price;
            PlayerPrefs.SetInt("Star",stars);
            Star_Count_text.text = PlayerPrefs.GetInt("Star", 0).ToString();
            IsSpent = true;
        }
        Debug.Log(PlayerPrefs.GetInt("Star", 0));
    }

    public void Set_Player(int Id)
    {
        if (IsSpent)
        {
            PlayerPrefs.SetInt("Player_Id", Id);
            IsSpent = false;
        }
    }
}
