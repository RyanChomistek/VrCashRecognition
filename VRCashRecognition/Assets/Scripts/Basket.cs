using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

    public int TargetValue;

    public int NumCorrect = 0;
    public int NumIncorrect = 0;
    public TextMesh text;
    private void Start()
    {
        text.text = "" + TargetValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        var currency = other.GetComponent<Currency>();
        if (currency)
        {
            if(currency.Amount == TargetValue)
            {
                NumCorrect++;
            }
            else
            {
                NumIncorrect--;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var currency = other.GetComponent<Currency>();
        if (currency)
        {
            if (currency.Amount == TargetValue)
            {
                NumCorrect--;
            }
            else
            {
                NumIncorrect++;
            }
        }
    }
}
