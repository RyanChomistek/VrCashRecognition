using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class Currency : MonoBehaviour {
    [Serializable]
    public class CurrencyMatPair
    {
        public int Amount;
        public Material Mat;
    }

    public int Amount = 1;
    public TextMeshPro text = null;

    public List<CurrencyMatPair> CurrencyPairs;
    public MeshRenderer Mesh;
    private void Start()
    {
        text.text = "" + Amount;
        Mesh.material = CurrencyPairs.Find(x => x.Amount == Amount).Mat;
    }
}
