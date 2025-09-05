using System.Collections;
using UnityEngine;

public class WorkSequenceOne : MonoBehaviour
{
    public GameObject IndicatorOne;
    public GameObject IndicatorTwo;
    public GameObject IndicatorThree;
    public GameObject IndicatorFour;

    public Vector3 workcellTwo;
    public Vector3 workcellThree;
    public Vector3 workcellFour;
    public Vector3 workcellFive;

    public GameObject XROrigin;

    public float transitionTime = 1.0f; // Time in seconds for smooth transition

    private bool hasMovedToTwo = false;
    private bool hasMovedToThree = false;
    private bool hasMovedToFour = false;
    private bool hasMovedToFive = false;

    void Update()
    {
        if (!hasMovedToTwo && IndicatorOne.activeInHierarchy)
        {
            hasMovedToTwo = true;
            StartCoroutine(MoveXROrigin(workcellTwo));
        }
        if (!hasMovedToThree && IndicatorTwo.activeInHierarchy)
        {
            hasMovedToThree = true;
            StartCoroutine(MoveXROrigin(workcellThree));
        }
        if (!hasMovedToFour && IndicatorThree.activeInHierarchy)
        {
            hasMovedToFour = true;
            StartCoroutine(MoveXROrigin(workcellFour));
        }
        if (!hasMovedToFive && IndicatorFour.activeInHierarchy)
        {
            hasMovedToFive = true;
            StartCoroutine(MoveXROrigin(workcellFive));
        }
    }

    IEnumerator MoveXROrigin(Vector3 targetPosition)
    {
        Vector3 startPos = XROrigin.transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < transitionTime)
        {
            XROrigin.transform.localPosition = Vector3.Lerp(startPos, targetPosition, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        XROrigin.transform.localPosition = targetPosition;
    }
}
