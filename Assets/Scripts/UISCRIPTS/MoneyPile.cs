using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

public class MoneyPile : MonoBehaviour
{
    [SerializeField] float lowestAmount;
    [SerializeField] float highestAmount;

    private float chosenAmount;
    private GameObject player;

    void Start()
    {
        chosenAmount = Random.Range(lowestAmount, highestAmount); // Picks value for money
        player = Money.playerRef;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject == player)
        {
            Money.currentMoney += chosenAmount;
            Money.onMoneyPickup?.Invoke(chosenAmount, null);
            Destroy(gameObject);
        }
    }
}