using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements.Experimental;

public class StartAssemblyTwoErrors : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;

    public Animator animator;
    public GameObject bolt;
    public GameObject ring;
    public GameObject cube; // Reference to the cube object

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;

        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Try to find the Animator if not assigned
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            CheckAndPlayAnimation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void CheckAndPlayAnimation()
    {
        if (cube.activeInHierarchy)
        {
            //Ring.SetActive(true);
            animator.Play("Pick_ring_error");
            StartCoroutine(WaitForAnimationToFinish("Pick_ring_error"));
        }
        else
        {
            //ring.SetActive(true);
            animator.Play("Pick_up_ring");
            StartCoroutine(WaitForAnimationToFinish("Pick_up_ring"));
        }
    }

    private IEnumerator WaitForAnimationToFinish(string animationName)
    {
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
    }
}