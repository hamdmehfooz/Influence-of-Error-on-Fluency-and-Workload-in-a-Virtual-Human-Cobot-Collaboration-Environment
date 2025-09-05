using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IKTargetFollow : MonoBehaviour
{
    // Assign these in the Inspector.
    public GameObject parentObject;
    public GameObject childObject;
    public Vector3 targetOffset;

    void Start()
    {
        // Make childObject a child of parentObject
        childObject.transform.SetParent(parentObject.transform);
        childObject.transform.localPosition = targetOffset;
        // Optionally, reset local position/rotation if needed:
        //childObject.transform.localPosition = Vector3.zero;
        //childObject.transform.localRotation = Quaternion.identity;
    }
}
