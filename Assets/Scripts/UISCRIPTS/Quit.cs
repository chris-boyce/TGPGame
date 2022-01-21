using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public bool _Quitting = false;

    public void ApplicationQuit()
    {
        if (_Quitting == true)
        {
            Application.Quit();
            Debug.Log("Application : Quit");
        }
    }

}
