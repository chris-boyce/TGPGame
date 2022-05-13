using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{

    //public GameObject objectToRotate;
    public float amplitude = 0.5f;
    public float frequency = 1.0f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {

        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f) * Time.deltaTime);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
