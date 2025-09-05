using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Task2ErrorTime : MonoBehaviour
{
    //public GameObject errorIndicator; // The object that indicates an error
    private string filePath;
    public GameObject TaskTwoErrorStart;
    public GameObject TaskTwoErrorEnd;
    private string logFilePath;
    private bool isTiming = false;
    private bool hasLogged = false;

    private float startTime;
    private float elapsedTime;

    private void Start()
    {

        // Define the file path for the CSV log
        logFilePath = Path.Combine("C:/Users/studentplay/Desktop/Hamd Mehfooz Khan/Thesis_Prototype/Assets/CSV Files", "Task2ErrorTime.csv");

        // If file does not exist, create it and write the header
        if (!File.Exists(logFilePath))
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Timestamp, Task 2 Error Time");
            }
        }
    }

    public void ActivateErrorStartObject()
    {
        TaskTwoErrorStart.SetActive(true);
    }

    void Update()
    {
        // Start timer when object A becomes active (first time only)
        if (TaskTwoErrorStart.activeInHierarchy && !isTiming && !hasLogged)
        {
            StartTimerErrorTwo();
        }

        // Stop timer and log when object B becomes active (only if not logged before)
        if (TaskTwoErrorEnd.activeInHierarchy && isTiming && !hasLogged)
        {
            StopTimerErrorTwo();
        }
    }

    void StartTimerErrorTwo()
    {
        isTiming = true;
        startTime = Time.time;
    }

    void StopTimerErrorTwo()
    {
        isTiming = false;
        elapsedTime = Time.time - startTime;
        hasLogged = true; // Prevent multiple logs

        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime - (minutes * 60) - seconds) * 1000);


        // Write elapsed time to CSV file
        File.AppendAllText(logFilePath, $"Task 2 error time,{DateTime.Now:yyyy-MM-dd HH:mm:ss},{minutes},{seconds},{milliseconds}\n");
    }

}

