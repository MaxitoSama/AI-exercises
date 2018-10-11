using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SteeringConf
{
    public const int num_priorities = 5;
}

abstract public class SteeringAbstract : MonoBehaviour {

    [Range(0, SteeringConf.num_priorities-1)]
    public int priority = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
