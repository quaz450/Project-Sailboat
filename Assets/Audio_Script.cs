using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Script : MonoBehaviour {

    public AudioClip Clip4, Clip5;
    public AudioSource Boat1, Boat2;
    public AudioClip[] clipArray1, clipArray2;

    // Use this for initialization
    void Start () {
        //Boat1.clip = Clip4;
        
        Boat1.volume = 0.035f;
        Boat2.volume = 0.05f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left")|| Input.GetKey("right"))
        {
            if (!Boat1.isPlaying)
            {
                int index = Random.Range(0, clipArray1.Length);
                Clip4 = clipArray1[index];
                Boat1.PlayOneShot(Clip4);
                Boat1.Play();
            }
        }
        if (Input.GetKey("up") || Input.GetKey("down"))
        {
            if (!Boat2.isPlaying)
            {
                int index = Random.Range(0, clipArray2.Length);
                Clip5 = clipArray2[index];
                Boat2.PlayOneShot(Clip5);
                Boat2.Play();
            }
        }

    }

}
