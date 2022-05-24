using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColour : MonoBehaviour
{
    // Start is called before the first frame update

    public Material hitMat;
    public Material originalMat;

    public GameObject Enemy;
    void Start()
    {
        Enemy.GetComponent<SkinnedMeshRenderer>().material = originalMat;
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            StartCoroutine(HitTimer());
        }
    }

    IEnumerator HitTimer()
    {
        Enemy.GetComponent<SkinnedMeshRenderer>().material = hitMat;
        yield return new WaitForSeconds(0.1f);
        Enemy.GetComponent<SkinnedMeshRenderer>().material = originalMat;
    }
}
