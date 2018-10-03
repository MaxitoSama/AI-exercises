using UnityEngine;
using System.Collections;

public class SteeringPursue : MonoBehaviour {

	public float max_seconds_prediction;
    public float max_distance;

	Move move;
    SteeringSeek seek;
    SteeringArrive arrive;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        arrive = GetComponent<SteeringArrive>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position, move.target.GetComponent<Move>().movement);
	}

	public void Steer(Vector3 target, Vector3 velocity)
	{
        // TODO 5: Create a fake position to represent
        // enemies predicted movement. Then call Steer()
        // on our Steering Seek / Arrive with the predicted position in
        // max_seconds_prediction time
        // Be sure that arrive / seek's update is not called at the same time
        Vector3 Distance=target-transform.position;
        float vel=0;

        if (move.movement.magnitude>0)
        {
            vel = move.max_mov_velocity / move.movement.magnitude;
        }

        // TODO 6: Improve the prediction based on the distance from
        // our target and the speed we have
        float dist = Distance.magnitude / max_distance;
        Debug.Log(dist);
        float average = (vel + dist) / 2;
        Vector3 vel_time = velocity * max_seconds_prediction * average;

        Vector3 Fposition = target + vel_time;
        arrive.Steer(Fposition);


       

    }
}
