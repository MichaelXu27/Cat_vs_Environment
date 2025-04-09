using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource pausedAudioSource;
    public AudioSource unpausedAudioSource;
    //public AudioClip unpausedAudio;
    //public AudioClip pausedAudio;

    bool isPausedPlaying  = true;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();        
    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            if (!isPausedPlaying)
            {
                isPausedPlaying = true;
                unpausedAudioSource.Pause();
                if(pausedAudioSource)
                    pausedAudioSource.UnPause();
            }
        }
        else
        {
            if (isPausedPlaying)
            {
                isPausedPlaying = false;
                if(pausedAudioSource)
                    pausedAudioSource.Pause();
                unpausedAudioSource.UnPause();
            }
        }
    }
}
