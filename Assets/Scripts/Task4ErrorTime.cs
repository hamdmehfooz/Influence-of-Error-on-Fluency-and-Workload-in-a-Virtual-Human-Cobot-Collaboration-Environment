using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Task4ErrorTime : MonoBehaviour
{//public GameObject errorIndicator; // The object that indicates an error
    private string filePath;
    public GameObject TaskFourErrorStart;
    public GameObject TaskFourErrorEnd;
    private string logFilePath;
    private bool isTiming = false;
    private bool hasLogged = false;

    private float startTime;
    private float elapsedTime;

    private void Start()
    {

        // Define the file path for the CSV log
        logFilePath = Path.Combine("C:/Users/studentplay/Desktop/Hamd Mehfooz Khan/Thesis_Prototype/Assets/CSV Files", "Task4ErrorTime.csv");

        // If file does not exist, create it and write the header
        if (!File.Exists(logFilePath))
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Timestamp, Task 4 Error Time");
            }
        }
    }

    public void ActivateErrorStartObject()
    {
        TaskFourErrorStart.SetActive(true);
    }

    void Update()
    {
        // Start timer when object A becomes active (first time only)
        if (TaskFourErrorStart.activeInHierarchy && !isTiming && !hasLogged)
        {
            StartTimerErrorFour();
        }

        // Stop timer and log when object B becomes active (only if not logged before)
        if (TaskFourErrorEnd.activeInHierarchy && isTiming && !hasLogged)
        {
            StopTimerErrorFour();
        }
    }

    void StartTimerErrorFour()
    {
        isTiming = true;
        startTime = Time.time;
    }

    void StopTimerErrorFour()
    {
        isTiming = false;
        elapsedTime = Time.time - startTime;
        hasLogged = true; // Prevent multiple logs

        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime - (minutes * 60) - seconds) * 1000);


        // Write elapsed time to CSV file
        File.AppendAllText(logFilePath, $"Task 4 error time,{DateTime.Now:yyyy-MM-dd HH:mm:ss},{minutes},{seconds},{milliseconds}\n");
    }
}
