using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    bool isMusic;
    // Start is called before the first frame update
    void Start()
    {
        isMusic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMusic)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;    
        }
    }
    public void SwitchAudio()
    {
        isMusic = !isMusic;
    }
}
