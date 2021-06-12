using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationScript : MonoBehaviour
{
    GravityAttractor[] attractors;
    GravityReceiver[] receivers;
    bool started = true;
    public float gravitationalConstant = 10;

    void Start()
    {
        attractors = GameObject.FindObjectsOfType<GravityAttractor>();
        receivers = GameObject.FindObjectsOfType<GravityReceiver>();
        Debug.Log("Controller initialized");
    }


    void FixedUpdate()
    {
        if (started)
        {
            Debug.Log(attractors.Length + " attractors found." + receivers.Length + "receivers found.");
            started = false;
        }
        
        foreach (GravityReceiver receiver in receivers)
        {
            foreach (GravityAttractor attractor in attractors)
            {
                if (receiver.gameObject != attractor.gameObject)
                {
                    Vector3 currentDirection = attractor.transform.position - receiver.transform.position;
                    Vector3 currentForce = gravitationalConstant * attractor.GetComponent<Rigidbody>().mass * receiver.GetComponent<Rigidbody>().mass * currentDirection / (Mathf.Pow(currentDirection.magnitude, 3));  
                    receiver.GetComponent<Rigidbody>().AddForce(currentForce);
                }
            }
        }
    }
}
