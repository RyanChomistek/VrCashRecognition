using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashLeftRead : ReadText
{
    public TextMeshPro Text;

    public override string GetText()
    {
        return "" + Text.text;
    }
}
