using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// HANDLES THE PAUSE SCENE/MENU BEING INVOKED IN THE GAME LEVEL , WILL DEFINE AND SET PARAMETERS TO SET A CORRECT ACTIVE PAUSE MENU
/// SCRIPT HANDLED BY PAUSEINVOKE OBJECT
/// </summary>

public class PauseMenu : MonoBehaviour
{
    int _PauseScreen = 7;
    public WeaponEquip weaponEquip;
    private bool CanRun;
    public GameObject _PlayerCamera;
    public SceneSwitcher _SceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {

        if (!(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(7)))
        {
            if(CanRun == true)
            {
                weaponEquip.CanShoot = true;
                CanRun = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {

                _PlayerCamera.GetComponent<Camera>().enabled = false;
                SceneManager.LoadScene(_PauseScreen, LoadSceneMode.Additive);
                GameObject.FindGameObjectWithTag("GUI").GetComponent<Canvas>().enabled = false;
                GameObject.FindGameObjectWithTag("GUITEXT").GetComponent<Canvas>().enabled = false;

            }
        }
        else
        {
            if(CanRun == false)
            {
                CanRun = true;
                weaponEquip.CanShoot = false;
            }

        }

    }





}
