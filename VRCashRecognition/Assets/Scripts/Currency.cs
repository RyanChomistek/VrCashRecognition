using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour {
    public int Amount = 1;
    public TextMeshPro text = null;
    private void Start()
    {
        text.text = "" + Amount;
    }
}
