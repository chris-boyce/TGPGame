using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControl : MonoBehaviour
{

    public Animator characterAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            characterAnimation.SetBool("isRunning", true);
        }
        else
        {
            characterAnimation.SetBool("isRunning", false);
        }

    }
}
