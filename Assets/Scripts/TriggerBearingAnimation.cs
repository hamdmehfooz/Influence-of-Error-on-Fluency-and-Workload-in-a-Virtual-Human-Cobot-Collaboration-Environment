using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBearingAnimation : MonoBehaviour
{
    public Animator animator; // Animator component for the object
    //public GameObject bearing;

    private void Start()
    {
        animator.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUpBearing"))
        {
            //bearing.SetActive(true);
            animator.Play("Pick_up_bearing");
        }
    }
}
