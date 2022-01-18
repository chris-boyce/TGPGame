using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public SceneSwitcher _SceneSwitcher;
    public bool _Paused;
    // Start is called before the first frame update
    void Start()
    { 
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_Paused == true)
            { 
                  Pause();

            }
            else
            {
                  Resume();
            }
        }





    }

    
    public void Pause()
    {
  

        //Holts In-Game Timer from executing , Holting any Timer Bound Actions
        Time.timeScale = 0f;
    //Set False By Default (doesnt show) - As intended
    _SceneSwitcher.LoadSceneAdditive("Pause");

    //Referenced in Update
    _Paused = true;
    }


    public void Resume()
    {
        //Make GameObject "PauseMenu" invisible to player

        //Set False By Default (doesnt show) - As intended
        _SceneSwitcher.UnloadScene("Pause");

        //Continues Regular Operation 
        Time.timeScale = 1f;

        //Referenced in Update
        _Paused = false;

    }


}
