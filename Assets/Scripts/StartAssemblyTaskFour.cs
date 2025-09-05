using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class StartAssemblyTaskFour : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;

    public Animator animator; // Animator component
    public GameObject bearing;
    public GameObject ring;
    public GameObject roboticArmIK; // Reference to the robotic arm IK object
    public GameObject cube; // Reference to the cube object
    public Transform targetTransform; // Object whose position & rotation need updating
    //public GameObject errorIndicator;
    public GameObject stopObject;
    private string logFilePath;
    public AudioSource assemblyStartSound;
    public GameObject TaskFourErrorEnd;

    public Vector3 newPosition = new Vector3(0.0649999976f, 1.42400002f, 0.393999994f); // Desired position
    public Vector3 newRotation = new Vector3(0f, 0f, 3.58f); // Desired rotation

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        // Define the file path for the CSV log
        logFilePath = Path.Combine("C:/Users/studentplay/Desktop/Hamd Mehfooz Khan/Thesis_Prototype/Assets/CSV Files", "Task4ErrorLog.csv");

        // If file does not exist, create it and write the header
        if (!File.Exists(logFilePath))
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Timestamp, Error Message");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only process this if the button isn't already pressed
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject; // Save the object that collided with the button
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            CheckAndPlayAnimation(); // Call the function to check cube state and play animation
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
            
            assemblyStartSound.Play();
            animator.Play("PickBearingError");
            StartCoroutine(WaitForAnimationAndMove("PickBearingError"));
        }
        if (stopObject.activeInHierarchy)
        {
            //errorSound.Play();
            animator.Play("Take_criclip_back");
            StartCoroutine(WaitForAnimationAndMove("Take_criclip_back"));
            LogError("Error identified");
            TaskFourErrorEnd.SetActive(true);
        }
        else
        {
            assemblyStartSound.Play();
            animator.Play("Pick_up_ring");
        }
    }

    IEnumerator WaitForAnimationAndMove(string animationName)
    {

        // Wait until PickBearingError animation starts
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationName));

        // Wait until animation is finished
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);

        // Update target transform position and rotation
        targetTransform.localPosition = newPosition;
        targetTransform.localRotation = Quaternion.Euler(newRotation);
    }

    private void LogError(string errorMessage)
    {
        // Create a timestamp
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Append to the CSV file
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{timestamp}, {errorMessage}");
        }

        Debug.Log($"Task 4 Error logged: {errorMessage} at {timestamp}");
    }
}
