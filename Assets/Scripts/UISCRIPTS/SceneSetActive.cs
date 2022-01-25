using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSetActive : MonoBehaviour
{
    public int _SceneIndex;
    private void Start()
    {
        SetActiveScene(_SceneIndex);
    }
    public void SetActiveScene(int scene_name)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_SceneIndex));

    }
}
