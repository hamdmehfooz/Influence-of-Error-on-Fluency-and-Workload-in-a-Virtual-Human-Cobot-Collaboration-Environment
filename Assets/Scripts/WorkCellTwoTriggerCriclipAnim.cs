using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkCellTwoTriggerCriclipAnim : MonoBehaviour
{
    public Animator animator;
    public GameObject errorIndicator;
    public GameObject cube;

    public GameObject TaskTwoErrorStart;

    private bool hasTriggered = false; // Ensure only one trigger event occurs

    private void Start()
    {
        animator.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("PickUpBearing"))
        {
            hasTriggered = true; // Prevent multiple triggers
            Debug.Log("xyz");

            // First play Pick_up_wascher and wait for it to finish, then check for Pick_up_bolt
            StartCoroutine(PlayWascherThenCheckBolt());
        }
    }

    IEnumerator PlayWascherThenCheckBolt()
    {
        // Play "Pick_up_wascher" animation and wait for it to finish
        yield return StartCoroutine(PlayAnimationAndWait("Pick_up_wascher"));

        // Wait for 5 seconds before checking conditions for Pick_up_bolt
        //yield return new WaitForSeconds(5f);

       /* if (!errorIndicator.activeInHierarchy && !cube.activeInHierarchy)
        {
            Debug.Log("abc");
            yield return StartCoroutine(PlayAnimationAndWait("Pick_up_bolt"));
        }*/
    }

    IEnumerator PlayAnimationAndWait(string animationName)
    {
        animator.Play(animationName);

        // Ensure animation has started
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationName));

        // Wait for animation to complete
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
    }
}
