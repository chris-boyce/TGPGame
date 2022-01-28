using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseSceneInvoke : MonoBehaviour
{
    public SceneSwitcher _SceneSwitcher;
    public GameObject _Canvas;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(8));

        Time.timeScale = 0;
        _Canvas.SetActive(true);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(8))
        {
            ActivateCanvas(_Canvas);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.UnloadScene(8);
                GameObject.Find("PlayerCam").GetComponent<Camera>().enabled = true;
         

                Time.timeScale = 1;
            }
        
        }
      
    }

    public void Resume()
{
        //Make GameObject "PauseMenu" invisible to player

        SceneManager.UnloadScene(8);
        GameObject.Find("PlayerCam").GetComponent<Camera>().enabled = true;
        Time.timeScale = 1;


    }
    public void ActivateCanvas(GameObject canvas)
    {

        canvas.SetActive(true);

    }
}