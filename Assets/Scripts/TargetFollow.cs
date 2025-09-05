using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // For grab functionality

public class TargetFollow : MonoBehaviour
{
    public Transform roboticArmEndEffector;  // The end effector or head of the robotic arm
    private XRGrabInteractable grabInteractable; // Reference to the grabbable component
    private bool isGrabbed = false; // To track if the target is being grabbed
    private Vector3 grabOffset; // To store the offset when grabbed

    void Start()
    {
        // Get the grabbable component (XRGrabInteractable)
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab); // New way to detect when grabbed
            grabInteractable.selectExited.AddListener(OnRelease); // New way to detect when released
        }
    }

    void Update()
    {
        if (isGrabbed)
        {
            // Calculate and apply the offset from the robotic arm's end effector
            Vector3 targetPosition = roboticArmEndEffector.position + grabOffset;
            transform.position = targetPosition;
        }
    }

    // Called when the target is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true; // The target is being grabbed

        // Calculate the relative offset between the robotic arm and the target
        grabOffset = transform.position - roboticArmEndEffector.position;
    }

    // Called when the target is released
    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false; // The target is released, stop following the robotic arm
    }
}