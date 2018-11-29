using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashMachineController : MonoBehaviour {

    public static CashMachineController Instance;

    public int targetAmount = 6;
    public int AmountLeft { get { return Mathf.Clamp(targetAmount - CashInput.currentAmount, 0, 10000); } }
    public int AmountChange { get { return CashInput.currentAmount - targetAmount; } }
    public CashInputController CashInput;
    public TextMeshPro AmountLeftText;

    public void Awake()
    {
        Instance = this;
        targetAmount = (int) (25 + Random.value * 50);
    }

    public void Update()
    {
        AmountLeftText.text = $"{AmountLeft} Dollars left";
    }

    public void OnCheck()
    {
        //check to see if they have the correct amount
        //then spit out change
    }
}
