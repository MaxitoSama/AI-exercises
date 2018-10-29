﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class FSM_Alarm : MonoBehaviour {
    private bool player_detected = false;
    private bool in_alarm = false;
    private bool go_alarm = false;
    private bool coming_home = false;
    private Vector3 patrol_pos;

    public GameObject alarm;
    public BansheeGz.BGSpline.Curve.BGCurve path;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == alarm)
            in_alarm = true;
    }

    // Update is called once per frame
    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            player_detected = true;
            go_alarm = true;
        }
    }

    // TODO 1: Create a coroutine that executes 20 times per second
    // and goes forever. Make sure to trigger it from Start()

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Patrol");
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(1.0f / 20.0f);
        if (!go_alarm)
        {
            StartCoroutine("Patrol");
        }
        else
        {
            patrol_pos = transform.position;
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = alarm.transform.position;
            path.gameObject.SetActive(false);
            StartCoroutine("PlayerDetected");
        }
    }
    IEnumerator PlayerDetected()
    {
        yield return new WaitForSeconds(1.0f / 20.0f);
        if (go_alarm)
        {
            Debug.Log("Testeo que te veo 1");

            Vector3 distance = transform.position - alarm.transform.position;
            if (distance.magnitude<=1.0f)
            {
                Debug.Log("Hellooooooo");
                go_alarm = false;
                coming_home = true;
            }
            StartCoroutine("PlayerDetected");
        }
        else
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = patrol_pos;
            StartCoroutine("ComeBack");
        }

    }
    IEnumerator ComeBack()
    {
        yield return new WaitForSeconds(1.0f / 20.0f);
        if(coming_home)
        {
            if ((transform.position - patrol_pos).magnitude <= 1.0f)
            {
                coming_home = false;
                path.gameObject.SetActive(true);
            }
            StartCoroutine("ComeBack");
        }
        else
        {
            StartCoroutine("Patrol");
        }
    }



    // TODO 2: If player is spotted, jump to another coroutine that should
    // execute 20 times per second waiting for the player to reach the alarm



    // TODO 3: Create the last coroutine to have the tank waiting to reach
    // the point where he left the path, and trigger again the patrol



}