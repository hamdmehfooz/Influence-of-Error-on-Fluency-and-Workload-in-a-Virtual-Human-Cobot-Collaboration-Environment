using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickBearingManual : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    public GameObject bearing;
    AudioSource sound;
    bool isPressed;
    public Animator animator; // Animator component for the object

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
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

    public void PlayAnimation()
    {
        bearing.SetActive(true);
        animator.Play("PickBearingError");
    }

    /*
    public GameObject GripperEnd;
    public Animator animator;
    private bool isPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GripperEnd") && !isPlaying)
        {
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation()
    {
        isPlaying = true; // Prevents multiple triggers
        animator.CrossFade("PickBearingError", 0.1f);

        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        isPlaying = false; // Allows re-triggering if needed
    }*/
}
