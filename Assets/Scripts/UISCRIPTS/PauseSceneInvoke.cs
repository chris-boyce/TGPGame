using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// HANDLER FOR THE PAUSE MENU SYSTEM
/// </summary>
public class PauseSceneInvoke : MonoBehaviour
{
    public SceneSwitcher _SceneSwitcher;
    public GameObject _Canvas;




    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(7));

        Time.timeScale = 0;
        _Canvas.SetActive(true);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(7))
        {
            ActivateCanvas(_Canvas);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.UnloadScene(2);

                GameObject.Find("PlayerCam").GetComponent<Camera>().enabled = true;
                GameObject.FindGameObjectWithTag("GUI").GetComponent<Canvas>().enabled = true;
                GameObject.FindGameObjectWithTag("GUITEXT").GetComponent<Canvas>().enabled = true;

                Time.timeScale = 1;
            }
        
        }
      
    }

    public void Resume()
{
        //Make GameObject "PauseMenu" invisible to player

        SceneManager.UnloadScene(2);
        
        GameObject.Find("PlayerCam").GetComponent<Camera>().enabled = true;
        GameObject.FindGameObjectWithTag("GUI").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("GUITEXT").GetComponent<Canvas>().enabled = true;

        Time.timeScale = 1;


    }
    public void ActivateCanvas(GameObject canvas)
    {

        canvas.SetActive(true);

    }
}