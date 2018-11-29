using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadTMP : ReadText
{

    public TextMeshPro text;

    public override string GetText()
    {
        return text.text;
    }
}
