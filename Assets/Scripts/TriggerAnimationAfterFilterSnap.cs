using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationAfterFilterSnap : MonoBehaviour
{
    public Animator animator;  // Animator component
    public GameObject bearing; // Bearing object
    public GameObject criclip; // Criclip object
    public GameObject bolt;    // Bolt object

    private bool animationTriggered = false;
    private bool hasPickedUpWasher = false; // Track if washer has been picked up

    private void OnTriggerEnter(Collider other)
    {
        if (!animationTriggered && other.CompareTag("Filter")) // Make sure Filter has the right tag
        {
            animationTriggered = true; // Prevents multiple triggers
            TriggerAnimation();
        }
    }

    void TriggerAnimation()
    {
        if (bearing.activeInHierarchy && !criclip.activeInHierarchy)
        {
            criclip.SetActive(true);
            animator.Play("Pick_up_wascher");
            hasPickedUpWasher = true; // Mark that washer is picked up
        }
        else if (criclip.activeInHierarchy && !bearing.activeInHierarchy)
        {
            bolt.SetActive(true);
            animator.Play("Pick_up_bolt");
        }
    }

    void Update()
    {
        if (hasPickedUpWasher)
        {
            // Check if the "Pick_up_wascher" animation has finished
            if (IsAnimationFinished("Pick_up_wascher"))
            {
                bolt.SetActive(true);
                // Play "Pick_up_bolt" after "Pick_up_wascher"
                animator.Play("Pick_up_bolt");
                hasPickedUpWasher = false; // Reset the flag
            }
        }
    }

    // Helper function to check if an animation has finished
    bool IsAnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f;
    }
}
