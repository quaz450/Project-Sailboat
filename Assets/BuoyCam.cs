using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuoyCam : MonoBehaviour {

    public bool buoyCamOn;
    public RaceProgress playerProgress;
	// Use this for initialization
	void Start () {
        buoyCamOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (buoyCamOn)
            {
                transform.localEulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); 
            }
            buoyCamOn = !buoyCamOn;
        }

        if (buoyCamOn)
        {
            transform.LookAt(playerProgress.getNextCP());
        }

    }
}
