using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(10, 1, 10);
        speed = 0.25f;

        follow = true;
	}
	
	// Update is called once per frame
	void Update () {

        ball_position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        direction = new Vector3(ball_position.x - position.x, ball_position.y - position.y, ball_position.z - position.z);
        direction = direction.normalized;

        if(follow)
        {
            transform.position += (direction * speed);
        }
        else
        {
            transform.position -= (direction * speed);
        }

        if(transform.position.y<-1)
        {
            transform.position = new Vector3(10, 1, 10);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            follow = !follow;
        }
    }


    public GameObject ball;
    Vector3 ball_position;
    Vector3 direction;
    Vector3 position;
    public float speed;
    public bool follow;
}
