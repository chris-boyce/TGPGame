using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneSwitcher : MonoBehaviour
{

    //
    public Animator _Animator;

    public float _Timer = 25.0f;
    public bool _TimerStart = false;
    //Loads Scene with passed in string "scene_name"
    public void LoadSingleScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
    }

    void Update()
    {
        TimerStart();
    }
    public void LoadSceneAdditive(string scene_name)
    {
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
    }

    public void UnloadScene(string scene_name)
    {

        SceneManager.UnloadSceneAsync(scene_name);



    }

    public void LoadTransition(string scene_name)
    {



        StartCoroutine(LoadLevel(scene_name));


    }

    IEnumerator LoadLevel(string scene_name)
    {
        _Animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene_name);

    }


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