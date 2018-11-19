using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchIndicator : MonoBehaviour {

    public Material On, Off;
    public bool IsOn { get; set; }

    private void Update()
    {
        var mats = GetComponent<MeshRenderer>().materials;
        if (IsOn)
        {
            Debug.Log("on");
            mats[1] = On;
        }
        else
        {
            mats[1] = Off;
        }
        GetComponent<MeshRenderer>().materials = mats;
    }
}
