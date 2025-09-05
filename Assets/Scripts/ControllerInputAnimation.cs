using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]
public class ControllerInputAnimation : MonoBehaviour
{
    [Header("Animation Settings")]
    public Animator animator; // Reference to the Animator
    public string ringAnimationName = "RingAnimation"; // Name of the ring animation
    public string screw2AnimationName = "Screw2Animation"; // Name of the screw 2 animation

    private InputData _inputData;
    public GameObject Ring;

    [Header("Timing Settings")]
    public float waitTime = 25f; // Time to wait for user input

    private bool isXPressed = false; // Tracks if X button is pressed
    private bool hasAnimationPlayed = false; // Tracks if an animation has already been played

    private void Start()
    {
        _inputData = GetComponent<InputData>(); // Ensure the InputData component is assigned
        StartCoroutine(WaitForInputOrTimeout()); // Start the coroutine
    }

    private IEnumerator WaitForInputOrTimeout()
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            // Check if the primary button (X button) on the left controller is pressed
            if (_inputData._leftController != null &&
                _inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Xbutton) &&
                Xbutton)
            {
                Ring.SetActive(true);
                Debug.Log("X button detected, playing ring animation.");
                PlayAnimation(ringAnimationName);
                yield break; // Exit the coroutine
            }

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // If no button press was detected within the wait time, play the Screw 2 animation
        if (!hasAnimationPlayed)
        {
            Debug.Log("Timeout reached, playing screw animation.");
            PlayAnimation(screw2AnimationName);
        }
    }

    private void PlayAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.Play(animationName);
            Debug.Log($"Playing animation: {animationName}");
            hasAnimationPlayed = true;
        }
        else
        {
            Debug.LogError("Animator not assigned.");
        }
    }
}
