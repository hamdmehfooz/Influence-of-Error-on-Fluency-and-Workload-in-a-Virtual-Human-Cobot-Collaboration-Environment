using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Task1AssemblyTime : MonoBehaviour
{
    private string filePath;

    private bool isTiming = false;
    private float startTime;
    private float endTime;

    void Start()
    {
        // Define folder and file path
        string folderPath = "C:/Users/hamdm/Thesis_Prototype/Assets/CSV Files";
        string fileName = "DataTask1.csv";  // Single file for all sessions
        filePath = Path.Combine(folderPath, fileName);

        // Ensure directory exists
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log($"Created Directory: {folderPath}");
        }

        // Ensure file exists and add a header if it's empty
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Task,Minutes,Seconds,Milliseconds\n");
            Debug.Log($"Created File: {filePath}");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision detected with: {other.name}");

        if (other.CompareTag("Start"))
        {
            startTime = Time.time;
            isTiming = true;
            Debug.Log("Button Pressed: Timer Started");
        }

        if (other.CompareTag("PickUpScrew3") && isTiming)
        {
            endTime = Time.time;
            isTiming = false;
            float elapsedTime = endTime - startTime;

            int minutes = (int)(elapsedTime / 60);
            int seconds = (int)(elapsedTime % 60);
            int milliseconds = (int)((elapsedTime - (minutes * 60) - seconds) * 1000);

            Debug.Log($"Bolt Snapped: Timer Stopped. Time: {minutes}m {seconds}s {milliseconds}ms");

            // Append data to the same file
            File.AppendAllText(filePath, $"Task 1,{minutes},{seconds},{milliseconds}\n");
            Debug.Log("Data saved successfully.");
        }
    }
}
