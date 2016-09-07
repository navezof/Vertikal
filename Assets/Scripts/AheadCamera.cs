using UnityEngine;
using System.Collections;

public class AheadCamera : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    Vector3 signedOffset;
    public float cameraSpeed;
    public float damping;

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

        if (move && !move.GetFacingRight())
        {
            signedOffset.x = offset.x * -1;
        }
        targetPosition = Vector3.Lerp(transform.position, target.position + signedOffset, Time.time * cameraSpeed);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, damping);
        lastTargetPosition = target.position;
	}
}
