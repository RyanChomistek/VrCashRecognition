using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class EyeRingController : MonoBehaviour {

    public Hand AttachedHand;

	// Use this for initialization
	void Start () {
        AttachedHand = transform.parent.GetComponent<Hand>();

    }
	
	// Update is called once per frame
	void Update () {
        CastingDebugController.DrawBoxCastBox(transform.position, new Vector3(.05f, .025f, .05f), transform.rotation, -transform.up, 1, Color.red);
        if (AttachedHand.GetTouchPadPress())
        {
            Debug.Log("eyering");
            var res = Physics.BoxCastAll(transform.position, new Vector3(.05f, .025f, .05f), -transform.up, transform.rotation);
            foreach(var hit in res)
            {
                Debug.Log(hit.collider.gameObject);
                var readText = hit.collider.gameObject.GetComponent<ReadText>();
                if (readText)
                {
                    readText.Read();
                }
            }
        }
    }
}
