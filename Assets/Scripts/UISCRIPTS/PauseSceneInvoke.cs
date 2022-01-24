using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSceneInvoke : MonoBehaviour
{

    public SceneSwitcher _SceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }



public void Resume()
{
    //Make GameObject "PauseMenu" invisible to player

    //Set False By Default (doesnt show) - As intended
    _SceneSwitcher.UnloadScene("Pause");

    //Continues Regular Operation 
    Time.timeScale = 1f;



}

}