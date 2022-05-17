using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColour : MonoBehaviour
{
    // Start is called before the first frame update

    public Material hitMat;
    public Material originalMat;

    [SerializeField]private GameObject Enemy;
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("EnemyColour");
    }

    // Update is called once per frame
    void Update()
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
        Enemy.GetComponent<MeshRenderer>().material = hitMat;
        yield return new WaitForSeconds(2);
        Enemy.GetComponent<MeshRenderer>().material = originalMat;
    }

}
