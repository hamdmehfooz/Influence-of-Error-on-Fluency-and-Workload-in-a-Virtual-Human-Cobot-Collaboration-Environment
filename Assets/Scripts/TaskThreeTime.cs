using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskThreeTime : MonoBehaviour
{
    public GameObject taskStartIndicator;
    public GameObject taskEndIndicator;

    public void ActivateStart()
    {
        taskStartIndicator.SetActive(true);
    }

    public void ActivateEnd()
    {
        taskEndIndicator.SetActive(true);
    }
}
