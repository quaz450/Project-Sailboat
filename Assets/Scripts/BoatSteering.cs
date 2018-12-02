using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSteering : MonoBehaviour {
    public float rotation;
    public float rotationLimit;
    public float rotationIncrement;
    public float drag = 0.9997f;

	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("left"))
        {
            rotation += -rotationIncrement * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            rotation += rotationIncrement * Time.deltaTime;
        }

        rotation = Mathf.Clamp(rotation, -rotationLimit, rotationLimit);

        this.transform.Rotate(Vector3.up, rotation);
        rotation *= drag;
	}
}
