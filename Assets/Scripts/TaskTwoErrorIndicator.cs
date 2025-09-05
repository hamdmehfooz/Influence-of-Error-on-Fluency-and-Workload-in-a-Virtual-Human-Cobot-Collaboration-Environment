using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TaskTwoErrorIndicator : MonoBehaviour
{

    public GameObject errorIndicator; // The object that indicates an error
    private string filePath;

    void Start()
    {
        // Define CSV file path
        string folderPath = "C:/Users/studentplay/Desktop/Hamd Mehfooz Khan/Thesis_Prototype/Assets/CSV Files";
        string fileName = "DataTask2.csv";
        filePath = Path.Combine(folderPath, fileName);
    }

    void Update()
    {
        // If errorIndicator becomes active, modify the last row in the CSV
        if (errorIndicator.activeInHierarchy)
        {
            AppendErrorToLastRow();
        }
    }

    void AppendErrorToLastRow()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("CSV file does not exist, cannot append error.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length < 2) // No data rows exist yet
        {
            Debug.LogWarning("No data entries exist in CSV file.");
            return;
        }

        // Modify last row
        string lastLine = lines[lines.Length - 1];
        if (lastLine.Contains("No Error")) // Only modify if "No Error" exists
        {
            lastLine = lastLine.Replace("No Error", "Error Identified");
            lines[lines.Length - 1] = lastLine;

            // Rewrite the file with the modified content
            File.WriteAllLines(filePath, lines);

            Debug.Log("Error Logged: Updated last row in DataTask2.csv");
            this.enabled = false; // Disable script after updating to prevent multiple modifications
        }
    }
}
