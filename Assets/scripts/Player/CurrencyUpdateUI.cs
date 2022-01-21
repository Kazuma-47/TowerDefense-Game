using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyUpdateUI : MonoBehaviour
{
    public TextMeshProUGUI Counter;
    public float money;


    void Update()
    {
        money = PlayerPrefs.GetFloat("Money");
        Counter.text = money.ToString();
    }
}
