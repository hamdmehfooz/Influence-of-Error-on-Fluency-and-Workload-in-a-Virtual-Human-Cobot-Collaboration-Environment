using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopAssemblyManual : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed = false;

    public Animator animator; 
    public GameObject criclip;    
    public GameObject criclip3;
    public string criclipAnimationName = "Pick_up_wascher"; 

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


        if (currentState.IsName(criclipAnimationName) || criclip.activeInHierarchy || criclip3.activeInHierarchy)
        {
            criclip.SetActive(false);
            criclip3.SetActive(true);
            animator.Play("Take_criclip_back");

            // Ensure the animator has switched to the new animation before proceeding
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Take_criclip_back"));
        }
    }
}
