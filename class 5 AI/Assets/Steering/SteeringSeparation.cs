﻿using UnityEngine;
using System.Collections;

public class SteeringSeparation : MonoBehaviour {

	public LayerMask mask;
	public float search_radius = 5.0f;
	public AnimationCurve falloff;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();

	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        Collider[] colliders=Physics.OverlapSphere(move.transform.position, search_radius,mask);
        // 2- For each of them calculate a escape vector using the AnimationCurve

        Vector3 TotalSum = Vector3.zero;

        foreach(Collider col in colliders)
        {
            Vector3 escape = (move.transform.position - col.transform.position);
            float distance = escape.magnitude;
            float factor = distance / search_radius;

            TotalSum += escape.normalized*move.max_mov_velocity*(1-falloff.Evaluate(factor));
        }

        // 3- Sum up all vectors and trim down to maximum acceleration
        move.AccelerateMovement(TotalSum);
	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
