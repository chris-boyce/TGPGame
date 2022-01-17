using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneSwitcher : MonoBehaviour 
{

   

    private void Start()
    {
        

    }


    private void Update()
    {
        
    }

    //Loads Scene with passed in string "scene_name"
    public void SceneSwitch(string scene_name)
    {
        
        SceneManager.LoadScene(scene_name);


    }



}
