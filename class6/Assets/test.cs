using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour {

    public GameObject destination;
    NavMeshAgent patata;

    // Use this for initialization
    void Start () {

        patata = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {

        patata.destination = destination.transform.position;

	}
}
