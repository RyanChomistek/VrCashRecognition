using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TrackerController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    public SteamVR_Controller.Device controller;

    public bool prevTriggerIsPressed = false;
    public bool triggerIsPressed = false;

    private void Update()
    {
        controller = GetComponent<Hand>().controller;
        prevTriggerIsPressed = triggerIsPressed;
        triggerIsPressed = controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }

    public bool getTriggerDown()
    {
        return prevTriggerIsPressed == false && triggerIsPressed == true;
    }
}
