using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioSource;

    [Space]

    public AudioClip Fone;
    public AudioClip ShowBets;
    public AudioClip ShowSumoStats;
    public AudioClip ShowSabotage;
    public AudioClip Confirm;
    public AudioClip WinMusic;
    public AudioClip LostMusic;
    public AudioClip BadEnd;
    public AudioClip GoodEnd;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        SetFoneMusic();
    }

    void Update()
    {
        if (!AudioSource.isPlaying)
        {
            SetFoneMusic();
        }
    }

    public void SetFoneMusic()
    {
        AudioSource.clip = Fone;
        AudioSource.Play();
    }

    public void SetShowBetsMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(ShowBets);
    }
    public void SetShowSumoStatsMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(ShowSumoStats);
    }
    public void SetShowSabotageMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(ShowSabotage);
    }
    public void SetConfirmMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(Confirm);
    }
    public void SetWinMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(WinMusic);
    }
    public void SetLostMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(LostMusic);
    }
    public void SetBadEndMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(BadEnd);
    }
    public void SetGoodEndMusic()
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(GoodEnd);
    }
}
