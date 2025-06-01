using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameAudio : MonoBehaviour
{
    public AudioSource MusicaudioSource, SFXAudioSource;
    bool isMusic, isSFX;
    // Start is called before the first frame update
    void Start()
    {
        isMusic = true;
        isSFX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMusic)
        {
            MusicaudioSource.mute = false;
        }
        else
        {
            MusicaudioSource.mute = true;
        }

        if (isSFX)
        {
            SFXAudioSource.mute = false;
        }
        else
        {
            SFXAudioSource.mute = true;
        }
    }

    public void MuteMusic()
    {
        isMusic= !isMusic;
    }
    public void MuteSounds()
    {
        isSFX = !isSFX;
    }

    
}
