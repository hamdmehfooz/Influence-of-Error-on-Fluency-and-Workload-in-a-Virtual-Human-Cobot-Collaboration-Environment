using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFalseCriclipAnimation : MonoBehaviour
{
    public Animator animator; // Animator component for the object
    public GameObject criclip;

    private void Start()
    {
        animator.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUpBearing"))
        {
            criclip.SetActive(true);
            animator.Play("Pick_up_wascher");
        }
    }
}
