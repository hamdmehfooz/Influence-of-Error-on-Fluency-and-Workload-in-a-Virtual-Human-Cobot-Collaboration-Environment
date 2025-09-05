using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartAssemblyOnButtonPressError : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    public GameObject criclip;
    AudioSource sound;
    bool isPressed;
    public Animator animator; // Animator component for the object
    public GameObject ring;

    // Start is called before the first frame update
    void Start()
    {
        criclip.SetActive(false);
        sound = GetComponent<AudioSource>();
        Debug.Log("Start() executed - Disabling criclip");
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
        ring.SetActive(true);
        animator.Play("Pick_up_ring");
    }

    void Update()
    {
        if (criclip.activeSelf)
        {
            Debug.Log("Criclip was enabled by something else!");
        }
    }
}
