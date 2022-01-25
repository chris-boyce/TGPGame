using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSwitcher : MonoBehaviour
{

    
    public Animator _Animator; //Interface to access / control animator within coded script


    //
    public float _Timer = 25.0f;
    public bool _TimerStart = false;



    //Each Frame - Statement Executed
    void Update()
    {
        TimerStart();
    }
    /// <summary>
    /// Loads Scene with interface passed Scene Name
    /// 
    /// LoadSceneMode = Additive - Loads scene without unloading current active scene / scenes
    /// </summary>
    public void LoadSceneAdditive(int scene_name)
    {
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Loads Scene with interface passed Scene Name
    /// 
    /// LoadSceneMode = Single - Unloads previous scene to load referenced scene
    /// </summary>
    public void LoadSingleScene(int scene_name)
    {
        SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
    }

    /// <summary>
    /// Loads Scene with interface passed Scene Name
    /// 
    /// LoadSceneMode = Single - Unloads previous scene to load referenced scene
    /// </summary>
    public void UnloadScene(int scene_name)
    {
        SceneManager.UnloadSceneAsync(scene_name);
        
    }
   public void UnloadSceneToPause(int scene_name)
    {
        SceneManager.UnloadSceneAsync(scene_name);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(7));
    }

    public void GameObjectActive(GameObject canvas)
    {

       
    }
    /// <summary>
    /// Loads Scene With the addition of a Transition 
    /// </summary>
    public void LoadTransitionSingle(int scene_name)
    {
        StartCoroutine(LoadLevelSingle(scene_name));
    }
    IEnumerator LoadLevelSingle(int scene_name)
    {
        _Animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene_name, LoadSceneMode.Single);

    }

    public void LoadTransitionAdditive(string scene_name )
    {
        StartCoroutine(LoadLevelAdditive(scene_name));
    }
    IEnumerator LoadLevelAdditive(string scene_name)
    {
        _Animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);

    }



    /// <summary>
    /// Loads Scene Delayed - TimerStart() Referenced in Update, so timer updates each frame , to eventually invoke if statement to load new scene.
    /// </summary>
    public void LoadDelaySingleScene(string scene_name)
    {
        _TimerStart = true;   
    }
    public void TimerStart()
    {

        if (_TimerStart == true)
        {
            _Timer -= 1.0f * Time.deltaTime;
            if (_Timer <= 0.0f)
            {
                SceneManager.LoadScene("GameMenu", LoadSceneMode.Single);
            }
        }
    }

}