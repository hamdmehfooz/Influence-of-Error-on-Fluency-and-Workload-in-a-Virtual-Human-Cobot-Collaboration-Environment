using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAssemblyCompleted : MonoBehaviour
{
    public AudioSource audioSource; // Assign in Inspector
    public AudioClip AssemblyCompleted; // Assign the sound you want to play

    // Method to be called in animation event
    public void PlayAssemblyCompletedSound()
    {
        if (audioSource && AssemblyCompleted)
        {
            audioSource.PlayOneShot(AssemblyCompleted); // Play without interrupting other sounds
        }
    }
}
