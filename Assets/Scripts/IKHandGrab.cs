using UnityEngine;

public class IKHandGrab : MonoBehaviour
{
    public Transform ikTarget; // Assign IK_Target in the inspector
    public Transform vrHand;   // Assign the VR hand transform
    private bool isGrabbing = false;

    void Update()
    {
        if (isGrabbing)
        {
            ikTarget.position = vrHand.position;
            ikTarget.rotation = vrHand.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRHand")) // Ensure your VR hand has this tag
        {
            isGrabbing = true;
            vrHand = other.transform; // Assign the VR hand transform dynamically
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VRHand"))
        {
            isGrabbing = false;
        }
    }
}
