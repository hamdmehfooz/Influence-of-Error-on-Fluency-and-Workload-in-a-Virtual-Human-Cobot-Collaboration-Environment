using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRingSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceBearing;
    public AudioSource audioSourceWascher;
    public AudioSource audioSourceBolt;
    public AudioClip soundClipRing;     // Assign the audio clip in the Inspector
    public AudioClip soundClipBearing;
    public AudioClip soundClipWascher;
    public AudioClip soundClipBolt;

    void PlaySound()
    {
        if (audioSource != null && soundClipRing != null)
        {
            audioSource.PlayOneShot(soundClipRing); // Play sound once
        }
    }

    void PlaySoundBearing()
    {
        if (audioSourceBearing != null && soundClipBearing != null)
        {
            audioSourceBearing.PlayOneShot(soundClipBearing); // Play sound once
        }
    }

    void PlaySoundWascher()
    {
        if (audioSourceWascher != null && soundClipWascher != null)
        {
            audioSourceWascher.PlayOneShot(soundClipWascher); // Play sound once
        }
    }

    void PlaySoundBolt()
    {
        if (audioSourceBolt != null && soundClipBolt != null)
        {
            audioSourceBolt.PlayOneShot(soundClipBolt); // Play sound once
        }
    }
}
