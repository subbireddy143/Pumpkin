using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Play_Button_Manager : MonoBehaviour
{
    public GameObject Play_Count;
    public GameObject Play_Button;
    public Text Play_Count_Text;
    public GameObject Player_obj;
    public static bool ispaused;

    public Player player;

    private string videoad = "video";
    public void Home()
    {
        SceneManager.LoadScene(0);
        Advertisement.Initialize("3601422" , true);
    }

    public void Pause()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        if (player.Isalive())
        {
            if (Advertisement.IsReady(videoad))
                Advertisement.Show(videoad);
            ispaused = true;
            Player_obj.SetActive(false);
            Play_Button.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Play()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            SoundManager.Instance.PlaySoundTrack(0);
        StartCoroutine(play());
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator play()
    {
        Play_Button.SetActive(false);
        Player_obj.SetActive(true);
        Time.timeScale = 0.01f;
        Play_Count_Text.text = "3";
        Play_Count.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        Play_Count_Text.text = "2";
        yield return new WaitForSeconds(0.01f);
        Play_Count_Text.text = "1";
        yield return new WaitForSeconds(0.01f);
        Play_Count_Text.text = "Go";
        yield return new WaitForSeconds(0.01f);
        Play_Count.SetActive(false);
        Time.timeScale = 1;
        ispaused = false;
        yield return null;
    }

    public void Ispaused(bool status)
    {
        ispaused = status;
    }

    public bool Ispaused()
    {
        return ispaused;
    }
}
