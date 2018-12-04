using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour {
    public WindDirection windDirection;
    GameObject windArrow;

    // Use this for initialization
    void Start () {
        windArrow = GameObject.FindGameObjectWithTag("WindArrow");
	}
	
	// Update is called once per frame
	void Update () {
        windArrow.transform.Rotate(0f, 0f, windDirection.getWindDirection());
		
	}
}
