using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    int _PauseScreen = 8;
    public GameObject _PlayerCamera;
    public SceneSwitcher _SceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (!(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(8)))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                        _PlayerCamera.GetComponent<Camera>().enabled = false;
                SceneManager.LoadScene(_PauseScreen, LoadSceneMode.Additive);

            }
        }

    }





}
