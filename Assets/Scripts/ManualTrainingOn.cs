using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManualTrainingOn : MonoBehaviour
{
    public GameObject button;
    public GameObject cube; // Object to activate
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed = false;
    public GameObject robotHead;
   // public GameObject IK;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        cube.SetActive(false); // Ensure cube is initially inactive
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
            cube.SetActive(true); // Activate the cube
            robotHead.SetActive(true);
           // IK.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
            presser = null;
        }
    }
}
