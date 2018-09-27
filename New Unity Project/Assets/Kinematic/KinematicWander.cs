﻿using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// number [-1,1] values around 0 more likely
	float RandomBinominal()
	{
		return Random.value * Random.value;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor
        Vector3 vel_vec=new Vector3(RandomBinominal(),0,RandomBinominal());
        move.SetMovementVelocity(move.mov_velocity+vel_vec);

	}
}
