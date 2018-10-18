using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    Vector3 des_vel;
    NavMeshAgent meshAgent;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hit, 10000.0f) == true)
                meshAgent.destination = hit.point;
        }

        Vector3 aux = meshAgent.velocity;
        des_vel = transform.InverseTransformVector(aux);
        des_vel.Normalize();

        animator.SetFloat("vel x", des_vel.x);
        animator.SetFloat("vel y", des_vel.z);

        if (meshAgent.remainingDistance > 0.0f)
        {
            animator.SetBool("movement", true);
        }
        else
            animator.SetBool("movement", false);
    }
}
