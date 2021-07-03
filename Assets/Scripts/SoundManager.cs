using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //The AudioSource to which we play any clips
    private AudioSource A_Source;

    //The audioclips which you should assign through inspector
    public AudioClip Clip_00;//button sound
    public AudioClip Clip_01;//star hit
    public AudioClip Clip_02;//Blade hit
    public AudioClip Clip_03;//High score
    //Singleton accessor
    public static SoundManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Add the audio source
        A_Source = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySoundTrack(int TrackID)
    {

        //Stop any playing music
        A_Source.Stop();

        switch (TrackID)
        {
            case 0:
                A_Source.PlayOneShot(Clip_00);
                break;

            case 1:
                A_Source.PlayOneShot(Clip_01);
                break;

            case 2:
                A_Source.PlayOneShot(Clip_02);
                break;

            case 3:
                A_Source.PlayOneShot(Clip_03);
                break;

            default:
                break;
        }

    }

}
