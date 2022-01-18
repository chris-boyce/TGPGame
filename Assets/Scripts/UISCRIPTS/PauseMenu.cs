using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //Enacts as a reference for the game object (expected to be a pausemenu) to execute function upon the entity
    public GameObject _PauseMenu;
    public bool _Paused;
    // Start is called before the first frame update
    void Start()
    {
        //Set False By Default (doesnt show) - As intended
        _PauseMenu.SetActive(false);
        
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
        //Make GameObject "PauseMenu" visible to player
        _PauseMenu.SetActive(true);

        //Holts In-Game Timer from executing , Holting any Timer Bound Actions
        Time.timeScale = 0f;

        //Referenced in Update
        _Paused = true;
    }


    public void Resume()
    {
        //Make GameObject "PauseMenu" invisible to player

        _PauseMenu.SetActive(false);

        //Continues Regular Operation 
        Time.timeScale = 1f;

        //Referenced in Update
        _Paused = false;

    }


}
