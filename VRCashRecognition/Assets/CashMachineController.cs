using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashMachineController : MonoBehaviour {

    public static CashMachineController Instance;

    public int targetAmount = 6;
    public CashInputController CashInput;
    public TextMeshPro AmountLeftText;

    public void Awake()
    {
        Instance = this;
        targetAmount = (int) (25 + Random.value * 50);
    }

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
