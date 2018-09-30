using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;

	Move move;
    int time = 0;
    Vector3 vel_vec;

    // Use this for initialization
    void Start () {
		move = GetComponent<Move>();
        vel_vec = new Vector3(RandomBinominal(), 0, RandomBinominal());
    }

	// number [-1,1] values around 0 more likely
	float RandomBinominal()
	{
		return Random.value + Random.value-1;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor

        time += 1;
        Debug.Log(time);


        if (time%100==0)
        {
            vel_vec = new Vector3(RandomBinominal(), 0, RandomBinominal());
            move.SetMovementVelocity(move.max_mov_velocity * vel_vec);
            Debug.Log("Hello");

        }


        //float angle = Mathf.Atan2(move.mov_velocity.x, move.mov_velocity.z);
        //Vector3 axis = new Vector3(0, 1, 0);
        //Quaternion rot = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, axis);
        //move.transform.rotation = rot;

    }
}
