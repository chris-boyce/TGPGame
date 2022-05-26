using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// HANDLES THE PAUSE SCENE/MENU BEING INVOKED IN THE GAME LEVEL , WILL DEFINE AND SET PARAMETERS TO SET A CORRECT ACTIVE PAUSE MENU
/// SCRIPT HANDLED BY PAUSEINVOKE OBJECT
/// </summary>

public class PauseMenu : MonoBehaviour
{
    int _PauseScreen = 2;

    public GameObject _PlayerCamera;
    public SceneSwitcher _SceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {

        if (!(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2)))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                _PlayerCamera.GetComponent<Camera>().enabled = false;
                SceneManager.LoadScene(_PauseScreen, LoadSceneMode.Additive);
                GameObject.FindGameObjectWithTag("GUI").GetComponent<Canvas>().enabled = false;
                GameObject.FindGameObjectWithTag("GUITEXT").GetComponent<Canvas>().enabled = false;

            }
        }

    }





}
