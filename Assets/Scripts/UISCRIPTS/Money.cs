using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    //Money vaules
    [SerializeField] GameObject playerSerialization;

    public static float currentMoney;
    public static GameObject playerRef;
    public static EventHandler onMoneyPickup; // Money pick up is parsed through object, not event args.

    //public GameObject moneyTest; // Remove debug reasons

    private void Awake()
    {
        playerRef = playerSerialization;

        // Remove segmented code, not necessary anymore, spawns zombie and calls OnDeath event.
        //var newObj = Instantiate(moneyTest, Vector3.back*10, Quaternion.identity);
        //newObj.GetComponent<Health>().Damage(30000);
        //
    }
}