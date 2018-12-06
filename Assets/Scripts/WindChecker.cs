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

    //AUDIO
    public AudioClip Water1, Clip2, Clip3;
    public AudioSource MoveSound, SeaSound, Wind;

    // Use this for initialization
    void Start () {
        windAngle = 0;
        rb = this.GetComponent<Rigidbody>();
        sailAngle = 0;

        //Audio
        MoveSound.clip = Water1;
        MoveSound.volume=0f;

        SeaSound.clip = Clip2;
        SeaSound.volume = 0.06f;

        Wind.clip = Clip3;
        Wind.volume = 1f;

        SeaSound.Play();
        MoveSound.Play();
        Wind.Play();
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

    //AUDIO
    void Update()
    {
        if (speed>8f)
        {            
            MoveSound.volume = 0.25f;
        }
        else if (speed > 7f)
        {
            MoveSound.volume = 0.2f;
        }
        else if (speed > 6f)
        {
            MoveSound.volume = 0.15f;
        }
        else if (speed > 5f)
        {
            MoveSound.volume = 0.1f;
        }
        else if (speed > 4f)
        {
            MoveSound.volume = 0.05f;
        }
        else if (speed > 3f)
        {
            MoveSound.volume = 0.025f;
        }
        else if (speed > 2f)
        {
            MoveSound.volume = 0.01f;
        }
        else if (speed > 1f)
        {
            MoveSound.volume = 0.008f;
        }
        else if (speed > 1f)
        {
            MoveSound.volume = 0.003f;
        }
        else
        {
            MoveSound.volume = 0.001f;
        }
    } 

    public float getWindDirection()
    {
        return wind.transform.forward.z;
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
