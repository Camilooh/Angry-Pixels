using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource SFXSource;
    public AudioClip HitClip;
    ProjectileLaunch projectileLaunch;
    // Start is called before the first frame update
    private void Start()
    {
        projectileLaunch = GameObject.FindObjectOfType<ProjectileLaunch>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SFXSource.PlayOneShot(HitClip);
        projectileLaunch.enemies--;
    }
}
