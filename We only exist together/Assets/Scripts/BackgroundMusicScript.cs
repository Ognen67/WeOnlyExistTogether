using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioSource[] sounds;
    public AudioSource intro;
    public AudioSource main;
    
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        intro = sounds[0];
        main = sounds[1];

        Invoke("startingMusicFinished", intro.clip.length);
    }

    void startingMusicFinished()
    {
        main.Play();
    }
}
