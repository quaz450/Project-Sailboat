using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCourseOrder : MonoBehaviour {

    public List<Transform> markerOrder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform getNextDestination(int numVisited)
    {
        return markerOrder[numVisited];
    }
}
