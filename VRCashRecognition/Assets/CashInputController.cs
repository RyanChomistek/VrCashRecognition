using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashInputController : MonoBehaviour {

    public int currentAmount;
    public TextMeshPro text;

    private void OnTriggerEnter(Collider other)
    {
        var currency = other.GetComponent<Currency>();
        if (currency)
        {
            currentAmount += currency.Amount;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var currency = other.GetComponent<Currency>();
        if (currency)
        {
            currentAmount -= currency.Amount;
        }
    }
}
