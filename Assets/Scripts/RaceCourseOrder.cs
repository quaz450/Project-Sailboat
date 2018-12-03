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
        if(numVisited == markerOrder.Count)
        {
            print("race over!");
            GameObject emptyGO = new GameObject("raceOver");
            emptyGO.transform.position = new Vector3(0, 0, 0);
            return new GameObject().transform;
        }
        return markerOrder[numVisited];
    }
}
