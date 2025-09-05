using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopAssembly : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed = false;

    public Animator animator; // Animator component controlling animations
    public GameObject actual_criclip;    // Reference to the 'xyz' object
    public GameObject criclip3;
    public GameObject bearing;
    public string criclipAnimationName = "Pick_up_wascher"; // Name of the bearing animation

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject; // Set presser so OnTriggerExit works correctly
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            StartCoroutine(CheckAndPlayAnimation()); // Use coroutine to wait for the animation
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
            presser = null; // Reset presser reference
        }
    }

    IEnumerator CheckAndPlayAnimation()
    {
        // Get current playing animation
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

        
        if (currentState.IsName(criclipAnimationName) || actual_criclip.activeInHierarchy || criclip3.activeInHierarchy)
        {
            actual_criclip.SetActive(false);
            criclip3.SetActive(true);
            animator.Play("Take_criclip_back");

            // Ensure the animator has switched to the new animation before proceeding
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Take_criclip_back"));

            // Wait for the full length of the animation
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
            actual_criclip.SetActive(false);
            // Activate bearing and play the next animation
            bearing.SetActive(true);
            animator.Play("Pick_up_bearing");

            // Ensure "Pick_up_bearing" actually starts before waiting
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Pick_up_bearing"));
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        }
    }
}
