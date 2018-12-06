using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WindChecker : MonoBehaviour {

    public Transform wind;
    public Wind windObject;
    public Transform sailTransform;
    public float speed;
    public float sailAngle;
    public float idealSailAngle;
    public float performanceRating;
    public float performanceFactor;
    Rigidbody rb;

    public float windAngle;
    
	// Use this for initialization
	void Start () {
        windAngle = 0;
        rb = this.GetComponent<Rigidbody>();
        sailAngle = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        speed = rb.velocity.magnitude;
        Vector3 windDirection =  wind.transform.forward;
        Vector3 boatDirection = transform.forward;
        Vector3 sailDirection = sailTransform.forward;
        windAngle = Vector3.SignedAngle(boatDirection, -windDirection, Vector3.up);
        sailAngle = Vector3.SignedAngle(-boatDirection, sailDirection, Vector3.up);


        if (windAngle * sailAngle < 0 || Mathf.Abs(windAngle) < 45)
        {
            performanceFactor = -0.01f;
        }

        else if (Mathf.Abs(windAngle) <= 90)
        {
            idealSailAngle = Mathf.Abs(windAngle) - 45;
            float diff = Mathf.Abs(idealSailAngle - Mathf.Abs(sailAngle));
            performanceFactor = 1 - diff/90;
        }
        else if (Mathf.Abs(windAngle) >90)
        {
            float idealSailAngle = windAngle / 2f;
            float diff = Mathf.Abs(idealSailAngle - sailAngle);
            performanceFactor = 1 - diff / 90;
        }
        float thrust = performanceFactor * windObject.force;
        if (speed < windObject.force)
        {
            rb.AddRelativeForce(Vector3.forward * windObject.force*performanceFactor);
        }

    }

    public float getWindDirection()
    {
        return windAngle;
    }

    public float getSailAngle()
    {
        return sailAngle;
    }

    public float getIdealSailAngle()
    {
        return idealSailAngle;
    }
}
