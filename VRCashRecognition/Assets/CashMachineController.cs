using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashMachineController : MonoBehaviour {

    public int targetAmount = 6;
    public CashInputController CashInput;
    public TextMeshPro AmountLeftText;

    public void Update()
    {
        AmountLeftText.text = $"{targetAmount - CashInput.currentAmount}";
    }

    public void OnCheck()
    {
        //check to see if they have the correct amount
        //then spit out change
    }
}
