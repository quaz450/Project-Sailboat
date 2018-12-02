using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindDirection : MonoBehaviour {

    public float windDirection;

	// Use this for initialization
	void Start () {
        windDirection = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") < 0)
        { 
            if (windDirection <= 0)
                windDirection = 360;
            windDirection = (windDirection - 1)*Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        { 
            if (windDirection >= 360)
                windDirection = 0;
            windDirection = (windDirection + 1) * Time.deltaTime;
        }

    }

    public float getWindDirection()
    {
        return windDirection;
    }
}
