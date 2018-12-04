using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

public void Exit()
    {
        Debug.Log("Exit Game successful!");
        Application.Quit();
    }
}
