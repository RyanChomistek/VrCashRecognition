﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    public static TimerController Instance;

    public float time;

	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
        Instance = this;
    }

	IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
            GetComponent<Text>().text = "Time : " + ((int) time);
        }
    }
}
