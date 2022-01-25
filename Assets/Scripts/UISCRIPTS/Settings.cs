using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{


    private int _SettingMenuSelect = 0;

    public GameObject _SettingScreen1;
    public GameObject _SettingScreen2;

    public void NextSettingScene()
    {
       
        //Element Access stops at 4 (0 - 4 / 5 Levels)
        if (_SettingMenuSelect >= 2)
            {
                _SettingMenuSelect = 2;

           
            }
        else
        {
            _SettingMenuSelect++;

            if(_SettingMenuSelect >= 2)
            {
                _SettingScreen1.SetActive(false);
                _SettingScreen2.SetActive(true);

            }

        }

    }
    public void PreviousSettingScene()
    {
      
        //Element Access stops at 4 (0 - 4 / 5 Levels)
        if (_SettingMenuSelect <= 1)
        {
            _SettingMenuSelect = 1;


        }
        else
        {
            _SettingMenuSelect--;

            if (_SettingMenuSelect <= 1)
            {
                _SettingScreen1.SetActive(true);
                _SettingScreen2.SetActive(false);

            }

        }


    }

}
