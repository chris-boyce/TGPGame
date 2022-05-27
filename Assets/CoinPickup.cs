using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public int AmountOfMoney;
    public TextMeshProUGUI MoneyText;
    private void Update()
    {
        MoneyText.text = "£" + AmountOfMoney.ToString();
    }

}
