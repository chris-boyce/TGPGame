using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSwitcher : MonoBehaviour
{

    
    public Animator _Animator; //Interface to access / control animator within coded script


    //Each Frame - Statement Executed
    void Update()
    {
        
    }
    /// <summary>
    /// Loads Scene with interface passed Scene Build Index
    /// 
    /// LoadSceneMode = Additive - Loads scene without unloading current active scene / scenes
    /// </summary>
    public void LoadSceneAdditive(int scene_index)
    {
        SceneManager.LoadScene(scene_index, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Loads Scene with interface passed Scene Build Index
    /// 
    /// LoadSceneMode = Single - Unloads previous scene to load referenced scene
    /// </summary>
    public void LoadSingleScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index, LoadSceneMode.Single);
    }

    /// <summary>
    /// Loads Scene with interface passed Scene Build Index
    /// 
    /// LoadSceneMode = Single - Unloads previous scene to load referenced scene
    /// </summary>
    public void UnloadScene(int scene_index)
    {
        SceneManager.UnloadSceneAsync(scene_index);
        
    }

    /// <summary>
    /// Loads Scene With the addition of a Transition 
    /// SceneLoadMode - Single
    /// </summary>
    public void LoadTransitionSingle(int scene_index)
    {
        StartCoroutine(LoadLevelSingle(scene_index));
    }
    IEnumerator LoadLevelSingle(int scene_index)
    {
        _Animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene_index, LoadSceneMode.Single);

    }

    /// <summary>
    /// Loads Scene With the addition of a Transition 
    /// SceneLoadMode - Additive
    /// </summary>
    public void LoadTransitionAdditive(int scene_index)
    {
        StartCoroutine(LoadLevelAdditive(scene_index));
    }
    IEnumerator LoadLevelAdditive(int scene_index)
    {
        _Animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene_index, LoadSceneMode.Additive);

    }

    /// <summary>
    /// Same as function "LoadSingleScene"
    /// Added for function name
    /// </summary>
    public void RestartScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index, LoadSceneMode.Single);
    }
}