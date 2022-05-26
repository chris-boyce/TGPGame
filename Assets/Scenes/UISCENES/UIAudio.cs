using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    public static AudioSource AudioSources;

    private void Start()
    {
        AudioSources = GetComponent<AudioSource>();
    }
    public static void PlaySoundEffect()
    {
        //Plays All Sounds With Given Preferences
        AudioClip PlaySound = Resources.Load("button_hover") as AudioClip;
        AudioSources.PlayOneShot(PlaySound, PlayerPrefs.GetFloat("UI"));
    }
}
