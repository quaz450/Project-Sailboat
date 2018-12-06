using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceProgress : MonoBehaviour {

    public int checkpointsVisited;
    public int nextCheckpointId;
    public RaceCourseOrder raceCourse;
    Transform nextCheckpointTransform;
    	
    // Use this for initialization
	void Start () {
        checkpointsVisited = 0;
        updateCheckpoint();
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    public void updateCheckpoint()
    {
        if (checkpointsVisited >= raceCourse.markerOrder.Count)
        {
            print("lap over");
            print("starting new lap");
            checkpointsVisited = 0;
        }
        nextCheckpointTransform = raceCourse.getNextDestination(checkpointsVisited);
        nextCheckpointId = nextCheckpointTransform.gameObject.GetComponentInChildren<CheckPoint>().id;
    }

    public Transform getNextCP()
    {
        return nextCheckpointTransform;
    }
}
