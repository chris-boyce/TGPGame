using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSetActive : MonoBehaviour
{
 
    public void SetActiveScene(int scene_index)
    {
      
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(scene_index));
        Debug.Log("Scene" + scene_index + "Is Set Active");
    }
}


