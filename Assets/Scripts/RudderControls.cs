using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderControls : MonoBehaviour {

    // public BoatSteering boatSteering;
    // Use this for initialization
    public BoatSteering boatSteering;
    public float rotation;
    public float rotationLimit = 80;
    public float rotationIncrement;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotation = boatSteering.rotation * -rotationLimit;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotation, transform.localEulerAngles.z);
    }
}
