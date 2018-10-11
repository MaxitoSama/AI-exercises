using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {

	public GameObject target;
	public GameObject aim;
	public Slider arrow;

	public float max_mov_velocity = 5.0f;
	public float max_mov_acceleration = 0.1f;
	public float max_rot_velocity = 10.0f; // in degrees / second
	public float max_rot_acceleration = 0.1f; // in degrees

	[Header("-------- Read Only --------")]
	public Vector3[] movement;
	public float[] rotation; // degrees

    private void Start()
    {
        movement = new Vector3[SteeringConf.num_priorities];
        rotation = new float[SteeringConf.num_priorities];

        for (int i=0;i<SteeringConf.num_priorities;i++)
        {
            movement[i].Set(0.0f, 0.0f, 0.0f);
        }
        for (int i = 0; i < SteeringConf.num_priorities; i++)
        {
            rotation[i] = 0.0f;
        }
    }

    // Methods for behaviours to set / add velocities
    public void SetMovementVelocity (Vector3 velocity, int priority) 
	{
		movement[priority] = velocity;
	}

	public void AccelerateMovement (Vector3 velocity, int priority) 
	{
		movement[priority] += velocity;
	}

	public void SetRotationVelocity (float rotation_velocity, int priority) 
	{
		rotation[priority] = rotation_velocity;
	}

	public void AccelerateRotation (float rotation_acceleration, int priority) 
	{
		rotation[priority] += rotation_acceleration;
	}

	
	// Update is called once per frame
	void Update () 
	{
        Vector3 currentMovement = Vector3.zero;
        float currentRotation = 0.0f;

        for (int i=0;i<SteeringConf.num_priorities;i++)
        {
            Debug.Log(i);
            if(movement[i].magnitude>0.0f)
            {
                currentMovement = movement[i];
                break;
            }
        }

        for (int i = 0; i < SteeringConf.num_priorities; i++)
        {
            if (rotation[i] > 0.0f)
            {
                currentRotation = rotation[i];
                break;
            }
        }
        // cap velocity
        if (currentMovement.magnitude > max_mov_velocity)
		{
            currentMovement.Normalize();
            currentMovement *= max_mov_velocity;
		}

		// cap rotation
		Mathf.Clamp(currentRotation, -max_rot_velocity, max_rot_velocity);

		// rotate the arrow
		float angle = Mathf.Atan2(currentMovement.x, currentMovement.z);
		aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

		// strech it
		arrow.value = currentMovement.magnitude * 4;

		// final rotate
		transform.rotation *= Quaternion.AngleAxis(currentRotation * Time.deltaTime, Vector3.up);

        // finally move
        currentMovement.y = 0.0f;
		transform.position += currentMovement * Time.deltaTime;
	}
}
