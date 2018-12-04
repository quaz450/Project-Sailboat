using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_ : MonoBehaviour {

    private GameObject pauseMenu;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        HidePauseMenu();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPauseMenu();
            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePauseMenu();
            }
        }
	}

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
}
