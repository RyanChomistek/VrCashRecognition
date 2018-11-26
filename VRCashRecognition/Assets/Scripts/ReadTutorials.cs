using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTutorials : ReadText {

    public override string GetText()
    {
        return GetComponent<Text>().text;
    }
}
