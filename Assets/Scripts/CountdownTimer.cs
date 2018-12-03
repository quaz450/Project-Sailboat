using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class CountdownTimer : MonoBehaviour {
    public float timeLeft;
    private Text text;
    bool ticking;
    private float startTime;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        ticking = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (ticking)
        {
            text.text = "Time: " + timeLeft.ToString("F2") + "s";
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                SceneManager.LoadScene(1);
            }
            
        }
	}

    public void startTicking()
    {
        Debug.Log(Time.time.ToString());
        startTime = Time.time/1000;
        ticking = true;
    }
}
