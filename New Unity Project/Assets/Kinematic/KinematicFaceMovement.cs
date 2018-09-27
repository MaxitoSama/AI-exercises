using UnityEngine;
using System.Collections;

public class KinematicFaceMovement : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
        // TODO 7: rotate the whole tank to look in the movement direction
        // Extremnely similar to TODO 2
        float angle = Mathf.Atan2(move.mov_velocity.x, move.mov_velocity.z);
        Vector3 axis = new Vector3(0, 1, 0);
        Quaternion rot = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, axis);
        move.transform.rotation = rot;
    }
}
