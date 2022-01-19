using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public bool _Quitting = false;
    // Start is called before the first frame update
    void Start()
    {

        if(_Quitting == true)
        {
            Application.Quit();
            Debug.Log("Application : Quit");
        }
     
    }

 
}
