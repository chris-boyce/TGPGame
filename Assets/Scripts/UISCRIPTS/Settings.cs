using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{


    private int _SettingMenuSelect = 0;
    public GameObject[] _SettingScreen;

    public void NextSettingScene()
    {
       
        //Element Access stops at 4 (0 - 4 / 5 Levels)
       
        //Check Method - Prevent going past indexed elements
        if (_SettingMenuSelect >= 2)
            {
             _SettingMenuSelect = 2;
            _SettingScreen[_SettingMenuSelect].SetActive(true);




        }
        else
        {
            //Makes Previous Setting Option Inactive
            _SettingScreen[_SettingMenuSelect].SetActive(false);

            //Makes Previous Setting Option Active
            _SettingMenuSelect++;
            _SettingScreen[_SettingMenuSelect].SetActive(true);

           

        }

    }
    public void PreviousSettingScene()
    {
      
        //Element Access stops at 4 (0 - 4 / 5 Levels)
        if (_SettingMenuSelect <= 0)
        {
            _SettingMenuSelect = 0;
            _SettingScreen[_SettingMenuSelect].SetActive(true);

        }
        else
        {
            _SettingScreen[_SettingMenuSelect].SetActive(false);

            _SettingMenuSelect--;
            _SettingScreen[_SettingMenuSelect].SetActive(true);


        }


    }

}
