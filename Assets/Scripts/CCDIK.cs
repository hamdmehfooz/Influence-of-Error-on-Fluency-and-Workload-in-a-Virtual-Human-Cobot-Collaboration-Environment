using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CCDIK : MonoBehaviour
{
    public Transform target;
    public Rigidbody[] joints;
    public float threshold = 0.01f;
    public int maxIterations = 5;  // Reduce iterations for stability
    public float torqueStrength = 20f;  // Adjust for smoother motion

    void FixedUpdate()
    {
        SolveIK();
    }

    void SolveIK()
    {
        if (joints.Length == 0 || target == null)
            return;

        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            for (int i = joints.Length - 2; i >= 0; i--)
            {
                Rigidbody joint = joints[i];
                Transform endEffector = joints[joints.Length - 1].transform;
                HingeJoint hinge = joint.GetComponent<HingeJoint>();

                if (hinge == null) continue;  // Skip if no Hinge Joint found

                // Compute vectors
                Vector3 toTarget = (target.position - joint.position).normalized;
                Vector3 toEndEffector = (endEffector.position - joint.position).normalized;

                // Compute rotation needed
                Vector3 rotationAxis = Vector3.Cross(toEndEffector, toTarget).normalized;
                float angle = Vector3.SignedAngle(toEndEffector, toTarget, rotationAxis);

                // Respect joint constraints
                JointLimits limits = hinge.limits;
                float currentAngle = hinge.angle; // Get current joint angle

                if (currentAngle + angle > limits.max)
                    angle = limits.max - currentAngle;
                if (currentAngle + angle < limits.min)
                    angle = limits.min - currentAngle;

                // Apply torque
                joint.AddTorque(-rotationAxis * (angle * torqueStrength * Time.fixedDeltaTime));

                // Stop if close enough to target
                if (Vector3.Distance(endEffector.position, target.position) < threshold)
                    return;
            }
        }
    }
}
