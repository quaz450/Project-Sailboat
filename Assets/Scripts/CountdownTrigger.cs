using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Text))]
public class CountdownTrigger : MonoBehaviour {

    public Text uiTimer;
    private CountdownTimer ct;
	// Use this for initialization
	void Start () {
        ct = uiTimer.GetComponent<CountdownTimer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            ct.startTicking();
            Destroy(this.gameObject);
        }
    }
}
