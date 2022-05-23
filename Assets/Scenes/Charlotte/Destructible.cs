using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public GameObject destroyedVersion; //Reference to shattered version of the object
                                        // Start is called before the first frame update

    public void Destroy()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
