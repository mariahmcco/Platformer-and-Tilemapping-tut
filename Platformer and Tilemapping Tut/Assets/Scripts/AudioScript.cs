using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioClip MusicClip2;

    public AudioSource MusicSource;
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))

        MusicSource.Play();
    }
}
