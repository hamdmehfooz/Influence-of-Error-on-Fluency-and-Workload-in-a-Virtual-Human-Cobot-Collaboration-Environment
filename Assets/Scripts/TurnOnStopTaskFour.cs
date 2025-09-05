using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnStopTaskFour : MonoBehaviour
{
    public GameObject StopObject;
    public void ActivateStopObject()
    {
        StopObject.SetActive(true);
    }
}
