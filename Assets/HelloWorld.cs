using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public float number = 0f;
    private bool isAlive = false;
    public GameObject cube;
    public Rigidbody rb;
    public Transform here;


    // Start is called before the first frame update
    void Start()
    {
        cube.transform.position = here.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

}
