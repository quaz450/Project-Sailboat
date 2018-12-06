using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour {
    public WindChecker currentStatus; 
    GameObject windArrow;
    GameObject sailAngle;

    // Use this for initialization
    void Start () {
        windArrow = GameObject.FindGameObjectWithTag("WindArrow");
        sailAngle = GameObject.FindGameObjectWithTag("SailAngle");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        windArrow.transform.Rotate(0f, 0f, currentStatus.getWindDirection());
        sailAngle.transform.Rotate(0f, 0f, currentStatus.getSailAngle());

    }
}
