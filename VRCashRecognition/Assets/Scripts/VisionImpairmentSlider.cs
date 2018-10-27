using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using Valve.VR.InteractionSystem;

public class VisionImpairmentSlider : MonoBehaviour {

    public PostProcessingBehaviour post;
    public LinearMapping LM;
    // Use this for initialization
    void Start () {
        //post.depthOfField.settings.

    }
	
	// Update is called once per frame
	void Update () {
        var dof = post.profile.depthOfField.settings;
        dof.focusDistance = Mathf.Clamp(LM.value, .01f, 1) * 2;
        dof.aperture = Mathf.Clamp(LM.value, .01f, 1) * 2;
        post.profile.depthOfField.settings = dof;
    }
}
