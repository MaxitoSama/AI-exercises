using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    public LayerMask mask;
    public LayerMask rayMask;
    public float distance = 4.0f;
    public Camera mycamera;

    Vector3 player_pos;
    Ray ray;

	// Use this for initialization
	void Start () {
        Vector3 player_pos=Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {

        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * 14, distance, mask);

        foreach (Collider col in colliders)
        {
            if (col.gameObject == gameObject)
                continue;

            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mycamera);

            if (GeometryUtility.TestPlanesAABB(planes, col.bounds))
            {
                ray = new Ray(transform.position, col.transform.position- transform.position);
                float ray_distance = (transform.position - col.transform.position).magnitude;
                player_pos=col.transform.position;

                RaycastHit hit;

                if(Physics.Raycast(ray,out hit, ray_distance, rayMask))
                {
                    Debug.Log("Player found but hiden");
                }
                else
                {
                    Debug.Log("Player found");

                }
            }
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position+transform.forward*14, distance);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, player_pos);
    }
}
