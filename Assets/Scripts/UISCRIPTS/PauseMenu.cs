using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _PauseMenu;
    public SceneSwitcher _SceneSwitcher;
    public bool _Paused = true;
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
            SceneManager.LoadScene(7, LoadSceneMode.Additive);

           
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
