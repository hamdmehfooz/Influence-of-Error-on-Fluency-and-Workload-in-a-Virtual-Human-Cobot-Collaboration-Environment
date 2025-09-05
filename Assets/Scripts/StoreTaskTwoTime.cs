using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StoreTaskTwoTime : MonoBehaviour
{
    public GameObject objectA; // Assign in Inspector
    public GameObject objectB; // Assign in Inspector

    private bool isTiming = false;
    private bool hasLogged = false; // Ensures time is recorded only once
    private float startTime;
    private float elapsedTime;
    private string filePath;

    void Start()
    {
        // Define CSV file path
        string folderPath = "C:/Users/studentplay/Desktop/Hamd Mehfooz Khan/Thesis_Prototype/Assets/CSV Files";
        string fileName = "DataTask2.csv";
        filePath = Path.Combine(folderPath, fileName);

        // Ensure directory exists
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Create file with header if it doesn’t exist
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Task,Date_Time,Minutes,Seconds,Milliseconds, Error\n");
        }
    }

    void Update()
    {
        // Start timer when object A becomes active (first time only)
        if (objectA.activeInHierarchy && !isTiming && !hasLogged)
        {
            StartTimer();
        }

        // Stop timer and log when object B becomes active (only if not logged before)
        if (objectB.activeInHierarchy && isTiming && !hasLogged)
        {
            StopTimer();
        }
    }

    void StartTimer()
    {
        isTiming = true;
        startTime = Time.time;
        Debug.Log("Timer Started: Object A is active.");
    }

    void StopTimer()
    {
        isTiming = false;
        elapsedTime = Time.time - startTime;
        hasLogged = true; // Prevent multiple logs

        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime - (minutes * 60) - seconds) * 1000);

        Debug.Log($"Timer Stopped: Object B is active. Time elapsed: {minutes}m {seconds}s {milliseconds}ms");

        // Write elapsed time to CSV file
        File.AppendAllText(filePath, $"Task 2,{DateTime.Now:yyyy-MM-dd HH:mm:ss},{minutes},{seconds},{milliseconds}\n");
    }
}
