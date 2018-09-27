using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {

        transform.position = new Vector3(0.0f, 1.0f, 0.0f);
    
    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, 0.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, -0.5f);
        }

        if (transform.position.y < -1)
        {
            transform.position = new Vector3(0 , 0, 0);
        }

    }
}
