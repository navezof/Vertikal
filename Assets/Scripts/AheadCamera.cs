using UnityEngine;
using System.Collections;

public class AheadCamera : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float fallingOffsetY;

    Vector3 signedOffset;
    public float cameraSpeed;
    public float damping = 0.5f;
    public float fallingDamping = 0.1f;

    Vector3 targetPosition;
    Vector3 lastTargetPosition;

    MoveComponent move;

    Vector3 currentVelocity;

    void Start()
    {
        lastTargetPosition = target.position;
        move = target.GetComponent<MoveComponent>();
    }

	// Update is called once per frame
	void Update ()
    {
        signedOffset = offset;
        float tmpDamping = damping;

        if (move)
        {
            if (!move.GetFacingRight())
                signedOffset.x = offset.x * -1;
            if (!move.GetGrounded())
            {
                signedOffset.y = fallingOffsetY;
                tmpDamping = fallingDamping;
            }
        }

        targetPosition = Vector3.Lerp(transform.position, target.position + signedOffset, Time.time * cameraSpeed);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, tmpDamping);
        lastTargetPosition = target.position;
	}
}
