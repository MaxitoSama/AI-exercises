using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour {

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two direction

        Vector3 desired_v = (move.target.transform.position - move.transform.position);
        Vector3 axis= new Vector3(0, 1, 0);
        float angle = Vector3.SignedAngle(move.movement, desired_v,axis);

        //float distance = (target - move.transform.position).magnitude;
        if (angle <= min_angle)
        {
            move.SetRotationVelocity(0.0f);
        }
        else
        {
            float acceleration=0;
            if (angle < slow_angle)
            {
                acceleration = move.max_rot_velocity * angle / slow_angle;
            }

            acceleration /= time_to_target;

            if (angle <0 )
            {
                acceleration -=acceleration;
            }
            move.AccelerateRotation(angle);
        }
    }
}
