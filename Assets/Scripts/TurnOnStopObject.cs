using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnStopObject : MonoBehaviour
{
    public GameObject StopObject;
    public void ActivateStopObject()
    {
        StopObject.SetActive(true);
    }

    public void InActivatestopObject()
    {
        StopObject.SetActive(false);
    }
}
