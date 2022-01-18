using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Ammo : MonoBehaviour
{

    public TextMeshProUGUI Text;
    private int ammoCount = 100;
    private int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Ammo:" + ammoCount;

        currentAmmo = ammoCount;
    }
}
