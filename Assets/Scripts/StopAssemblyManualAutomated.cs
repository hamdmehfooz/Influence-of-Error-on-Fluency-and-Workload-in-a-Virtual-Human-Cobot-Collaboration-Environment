using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO; // Required for file operations

public class StopAssemblyManualAutomated : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed = false;

    public Animator animator;

    public AudioSource recoverySound;
    // public GameObject actual_criclip;
    //public GameObject criclip3;
    // public GameObject bearing;
    // public GameObject cube; // Reference to the cube object
    //public GameObject errorIndicator;
    // public string criclipAnimationName = "Pick_up_wascher";

    private string logFilePath;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        // Define the file path for the CSV log
        //logFilePath = Path.Combine("C:/Users/studentplay/Desktop/Hamd Mehfooz Khan/Thesis_Prototype/Assets/CSV Files", "Task2ErrorLog.csv");

        // If file does not exist, create it and write the header
        /*if (!File.Exists(logFilePath))
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Timestamp, Error Message");
            }
        }*/
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
            //errorIndicator.SetActive(true);
            //Debug.Log("session2 error");

            // Log the error to CSV file
          //  LogError("Error identified");

            StartCoroutine(CheckAndPlayAnimation());
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

    IEnumerator CheckAndPlayAnimation()
    {
        /*AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);

        if (currentState.IsName(criclipAnimationName) || actual_criclip.activeInHierarchy || criclip3.activeInHierarchy)
        {
            actual_criclip.SetActive(false);
            animator.Play("Take_criclip_back");

            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Take_criclip_back"));
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);

            // Wait for 10 seconds
            yield return new WaitForSeconds(10f);

            // Check if cube is active
            if (!cube.activeInHierarchy)
            {
                actual_criclip.SetActive(false);*/
        recoverySound.Play();
        animator.Play("Pick_up_bearing");

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Pick_up_bearing"));
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
            //}
        //}
    }

 /*   private void LogError(string errorMessage)
    {
        // Create a timestamp
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Append to the CSV file
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{timestamp}, {errorMessage}");
        }

        Debug.Log($"Task 2 Error logged: {errorMessage} at {timestamp}");
    }*/
}
