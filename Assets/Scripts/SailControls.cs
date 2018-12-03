using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailControls : MonoBehaviour
{

    // public BoatSteering boatSteering;
    // Use this for initialization
    public float rotation;
    public float rotationLimit = 90;
    public float rotationIncrement;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            rotation += -rotationIncrement * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            rotation += rotationIncrement * Time.deltaTime;
        }

        rotation = Mathf.Clamp(rotation, -rotationLimit, rotationLimit);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotation, transform.localEulerAngles.z);
    }
}