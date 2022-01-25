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
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(7))
        {

            ActivateCanvas(_Canvas);
        }
        else
        {

            _Canvas.SetActive(false);
        }    
    }

    public void Resume()
{
    //Make GameObject "PauseMenu" invisible to player

    //Set False By Default (doesnt show) - As intended
    _SceneSwitcher.UnloadScene(7);

    //Continues Regular Operation 
    Time.timeScale = 1f;



}
    public void ActivateCanvas(GameObject canvas)
    {

        canvas.SetActive(true);

    }
}