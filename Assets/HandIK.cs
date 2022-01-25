using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : MonoBehaviour
{
    [SerializeField]
    private WeaponSwitcher weaponSwitcher;

    Transform target;

    [SerializeField]
    private string targetTag = "LeftHand";

    [SerializeField]
    private Transform defaultPos;

    // Start is called before the first frame update
    void Start()
    {
		if (!weaponSwitcher) {
            Debug.LogError("HANDIK: Needs a weaponswitcher referenced");
		}

        UpdateHeldItem();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.transform.position;
        transform.rotation = target.transform.rotation;
    }

    public void UpdateHeldItem() {
        GameObject item = weaponSwitcher.GetCurrentWeapon();

        Transform newTarget = null;
        foreach (Transform trans in item.transform) {
            if (trans.tag == targetTag) {
                newTarget = trans.GetComponent<Transform>();
            }
        }

		if(!newTarget) {
            Debug.Log("HANDIK: Can't find hand position with \"" + tag + "\" tag in " + item + "!");
            target = defaultPos;
            return;
		}

        target = newTarget;
    }
}
