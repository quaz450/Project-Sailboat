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
        if (Input.GetKeyDown("left"))
        { 
            windDirection = (windDirection - 1)*Time.deltaTime;
            if (windDirection < 0)
                windDirection += 360;
        }
        else if (Input.GetKeyDown("right"))
        { 
            windDirection = (windDirection + 1) * Time.deltaTime;
            if (windDirection > 360)
                windDirection -= 360;
        }

    }

    public float getWindDirection()
    {
        return windDirection;
    }
}
