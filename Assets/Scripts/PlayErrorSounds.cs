using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayErrorSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip errorSound;
    // Start is called before the first frame update
    void PlayErrorSound()
    {
         audioSource.PlayOneShot(errorSound); // Play sound once
    }
}
