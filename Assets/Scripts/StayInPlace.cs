using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInPlace : MonoBehaviour {
    public Transform startPosition;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        startPosition = transform;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, startPosition.position) > 2)
        {
            transform.LookAt(startPosition);
            rb.AddRelativeForce(Vector3.forward * 5);
        }
	}
}
