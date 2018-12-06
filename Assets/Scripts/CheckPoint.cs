using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [RequireComponent(typeof(Collider))]
    public class CheckPoint : MonoBehaviour
    {

    public int id;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Something Touching Checkpoint!");
        if (col.gameObject.CompareTag("Player"))
        {
            print("it's the player!");
            RaceProgress playerProgress = col.gameObject.GetComponent<RaceProgress>();
            if(playerProgress.nextCheckpointId == this.id)
            {
                playerProgress.checkpointsVisited++;
                playerProgress.updateCheckpoint();
            }
        }
    }
}


