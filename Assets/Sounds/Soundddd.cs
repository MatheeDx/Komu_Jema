using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundddd : MonoBehaviour
{
    public AudioSource source;
    AudioClip clip;

    public void PlaySteps()
    {
        source.Play();
    }
    public void StopSteps()
    {
        source.Stop();
    }
    public void AudioPlay(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
