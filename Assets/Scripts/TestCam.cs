using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera cam;

    private void Start()
    {
     cam = cam.GetComponent<Camera>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("WallHit");
        }
    }

}
