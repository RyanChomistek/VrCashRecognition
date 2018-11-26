using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadString : ReadText {
    public string Text;

    public override string GetText()
    {
        return Text;
    }
}
