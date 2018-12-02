using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WindChecker : MonoBehaviour {

    public Transform wind;
    public Wind windObject;
    public float speed;
    Rigidbody rb;

    public float windAngle;
    
	// Use this for initialization
	void Start () {
        windAngle = 0;
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 windDirection =  wind.transform.forward;
        Vector3 boatDirection = transform.forward;
        windAngle = Mathf.Abs(Vector3.SignedAngle(boatDirection, -windDirection, Vector3.up));

        if(windAngle>40 && windAngle < 60)
        {
            rb.AddForce(transform.forward * windObject.force * 0.8f);
        }
        if(windAngle>60 && windAngle < 130)
        {
            rb.AddRelativeForce(Vector3.forward*windObject.force);
        }

        speed = rb.velocity.magnitude;
	}
}
