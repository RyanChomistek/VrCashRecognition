using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class EyeRingController : MonoBehaviour {
    
    public TrackerController AttachedTracker;

    public delegate void OnEyeringUsedDelegate();

    [HideInInspector]
    public event OnEyeringUsedDelegate OnEyeringUsed;

    // Use this for initialization
    void Start () {
        //AttachedTracker = transform.parent.GetComponent<TrackerController>();
    }
	
	// Update is called once per frame
	void Update () {
        CastingDebugController.DrawBoxCastBox(transform.position, new Vector3(.05f, .025f, .05f), transform.rotation, -transform.up, 1, Color.red);

        Debug.Log(AttachedTracker.getTriggerDown());

        if (AttachedTracker.getTriggerDown())
        {
            Debug.Log("eyering");
            var res = Physics.BoxCastAll(transform.position, new Vector3(.05f, .025f, .05f), -transform.up, transform.rotation);
            foreach(var hit in res)
            {
                Debug.Log(hit.collider.gameObject);

                var readText = hit.collider.gameObject.GetComponent<ReadText>();
                if (readText)
                {
                    OnEyeringUsed.Invoke();
                    readText.Read();
                    return;
                }
            }
        }
    }
}
