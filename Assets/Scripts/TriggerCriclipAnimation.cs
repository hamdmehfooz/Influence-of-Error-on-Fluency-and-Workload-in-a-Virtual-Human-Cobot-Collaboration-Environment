using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCriclipAnimation : MonoBehaviour
{
    public Animator animator;
   // public GameObject coil;

    private void Start()
    {
        animator.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUpWascher"))
        {
            //coil.SetActive(true);
            animator.Play("Pick_up_wascher");
        }
    }
}
