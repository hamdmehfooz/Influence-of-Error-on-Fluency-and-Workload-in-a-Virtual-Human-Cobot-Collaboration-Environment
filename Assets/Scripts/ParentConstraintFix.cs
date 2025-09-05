using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ParentConstraintFix : MonoBehaviour
{
    private ParentConstraint parentConstraint;

    void Awake()
    {
        gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void Start()
    {
        parentConstraint = GetComponent<ParentConstraint>();
        if (parentConstraint != null)
        {
            parentConstraint.weight = 1; // Ensure the constraint is active
            parentConstraint.constraintActive = true;
        }
    }

    void LateUpdate()
    {
        if (parentConstraint != null)
        {
            parentConstraint.weight = 1; // Reapply parent constraint influence
        }
    }

}
