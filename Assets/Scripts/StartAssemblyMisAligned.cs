using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartAssemblyMisAligned : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed = false;

    public Animator animator;
    //public GameObject ring;
    public GameObject cube; // Reference to the cube object
                            // public string criclipAnimationName = "Pick_up_wascher";
    public Transform targetTransform;
    public Vector3 newPosition = new Vector3(0.0649999976f, 1.42400002f, 0.393999994f); // Desired position
    public Vector3 newRotation = new Vector3(0f, 0f, 3.58f); // Desired rotation
    //public Transform animationStartTransform; // Set this to the first frame's position/rotation
    //public float transitionDuration = 1.0f;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            CheckAndPlayAnimation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
            presser = null;
        }
    }

    public void CheckAndPlayAnimation()
    {
        if (cube.activeInHierarchy)
        {
            /*Transform arm = transform;
            Vector3 startPos = arm.position;
            Quaternion startRot = arm.rotation;
            Vector3 targetPos = animationStartTransform.position;
            Quaternion targetRot = animationStartTransform.rotation;

            float time = 0;
            while (time < transitionDuration)
            {
                time += Time.deltaTime;
                arm.position = Vector3.Lerp(startPos, targetPos, time / transitionDuration);
                arm.rotation = Quaternion.Slerp(startRot, targetRot, time / transitionDuration);
                yield return null;
            }

            arm.position = targetPos;
            arm.rotation = targetRot;*/
            //ring.SetActive(true);
            animator.Play("Pick_ring_error");
            StartCoroutine(WaitForAnimationAndMove());
        }
        else
        {
            // ring.SetActive(true);
           // animator.Play("Pick_up_ring");
        }
    }

    IEnumerator WaitForAnimationAndMove()
    {
        // Update target transform position and rotation
        targetTransform.localPosition = newPosition;
        targetTransform.localRotation = Quaternion.Euler(newRotation);

        // Wait until PickBearingError animation starts
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Pick_ring_error"));

        // Wait until animation is finished
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);



        // Update target transform position and rotation
       // targetTransform.localPosition = newPosition;
        //targetTransform.localRotation = Quaternion.Euler(newRotation);


    }
}

