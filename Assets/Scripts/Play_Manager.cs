using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Play_Manager : MonoBehaviour
{
    private string ad = "3601422";
    private string videoad = "video";
    static int adcount = 0;

    public GameObject Replay;
    Star_Count star_Count;
    int current_Stars;
    Animator anim;
    Player player;
    public Text Stars;

    float Score;
    public Text Score_text;

    float High_Score;
    bool new_High;
    public Text High_Score_text;

    Play_Button_Manager PBM;

    public GameObject High_Score_Display;
    public GameObject Score_Display;
    public GameObject Star_Display;

    public Text Score_Display_text;
    public Text Star_Display_text;

    public GameObject Blade;

    private void Start()
    {
        Advertisement.Initialize(ad, true);

        player = GetComponent<Player>();
        star_Count = new Star_Count();
        current_Stars = 0;
        anim = GetComponent<Animator>();
        anim.SetBool("Isalive", true);
        Stars.text = PlayerPrefs.GetInt("Star",0).ToString();

        Score_text.text = "0";
        new_High = false;
        
        High_Score = PlayerPrefs.GetFloat("High_Score", 0);
        Debug.Log(High_Score);
        High_Score_text.text = High_Score.ToString("0");

        PBM = gameObject.AddComponent<Play_Button_Manager>();

        Blade.SetActive(false);
    }

    private void Update()
    {
        if (player.Isalive() && !PBM.Ispaused())
        {
            Score += Time.deltaTime;
            Score_text.text = Score.ToString("0");
            if (Score >= 100)
                Blade.SetActive(true);
            if (Score >= High_Score)
            {
                Debug.Log("highScore");
                new_High = true;
                High_Score = Score;
                PlayerPrefs.SetFloat("High_Score", High_Score);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Blade" && player.Isalive())
        {
            //Destroy pumpkin
            //Sound_Manager.play("Blade_Hit");
            StartCoroutine(Dead());
            adcount++;
            if (PlayerPrefs.GetInt("Sound", 1) == 1)
                SoundManager.Instance.PlaySoundTrack(2);
            if (Advertisement.IsReady(videoad) && adcount == 3)
            {
                Advertisement.Show(videoad);
                adcount = 0;
            }   
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star" && player.Isalive())
        {
            //Increment Star count
            //Sound_Manager.play("Star_Hit");
            Destroy(collision.gameObject);
            if (PlayerPrefs.GetInt("Sound", 1) == 1)
                SoundManager.Instance.PlaySoundTrack(1);
            star_Count.Increment();
            Stars.text = PlayerPrefs.GetInt("Star", 0).ToString();
            current_Stars++;
            //Debug.Log(PlayerPrefs.GetInt("Star",0));
        }
    }

    IEnumerator Dead()
    {
        anim.SetBool("Isalive", false);
        player.Isalive(false);
        High_Score_text.text = High_Score.ToString("0");
        Score_Display_text.text = Score.ToString("0");
        Star_Display_text.text = current_Stars.ToString("0");
        yield return new WaitForSeconds(1f);
        High_Score_Display.SetActive(true);
        Score_Display.SetActive(true);
        if (new_High)
        {
            if (PlayerPrefs.GetInt("Sound", 1) == 1)
                SoundManager.Instance.PlaySoundTrack(3);
            yield return new WaitForSeconds(0.2f);
            if (PlayerPrefs.GetInt("Sound", 1) == 1)
                SoundManager.Instance.PlaySoundTrack(3);
            yield return new WaitForSeconds(0.1f);
            if (PlayerPrefs.GetInt("Sound", 1) == 1)
                SoundManager.Instance.PlaySoundTrack(3);
        }
        yield return new WaitForSeconds(1f);
        Star_Display.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Replay.SetActive(true);
        yield return null;
    }

}
