using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoilAnimation : MonoBehaviour
{
    public Animator animator; // Animator component for the object
  //  public GameObject coil;
   // public GameObject bolt;
   // public GameObject cube; // Reference to the cube object

    private void Start()
    {
        animator.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUpWascher"))
        {
            //if (cube.activeInHierarchy)
            //{
                StartCoroutine(RunAnimation());
                /*coil.SetActive(true);
                animator.Play("Pick_up_wascher");

                // Wait until PickBearingError animation starts
                yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Pick_up_wascher"));

                // Wait until animation is finished
                yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);*/
            //}
        }
    }

    IEnumerator RunAnimation()
    {
       // coil.SetActive(true);
        animator.Play("Pick_up_wascher");

        // Wait until PickBearingError animation starts
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Pick_up_wascher"));

        // Wait until animation is finished
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);

       // bolt.SetActive(true);
        animator.Play("Pick_up_bolt");

        // Wait until PickBearingError animation starts
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Pick_up_bolt"));

        // Wait until animation is finished
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
    }
}
