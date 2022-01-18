using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneSwitcher : MonoBehaviour 
{
    //Loads Scene with passed in string "scene_name"
    public void LoadSingleScene(string scene_name)
    {    
        SceneManager.LoadScene(scene_name , LoadSceneMode.Single);
    }

    public void LoadSceneAdditive(string scene_name)
    {
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
    }

    public void UnloadScene(string scene_name )
    {
        
        SceneManager.UnloadSceneAsync(scene_name);

        
        
    }
}