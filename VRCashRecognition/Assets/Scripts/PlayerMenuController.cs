using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerMenuController : MonoBehaviour {
    private Vector3 oldPosition;
    private Quaternion oldRotation;

    private float attachTime;

    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

    public delegate void OnMenuAttachedDelegate();

    [HideInInspector]
    public event OnMenuAttachedDelegate OnMenuAttached;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        //if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
        //if (hand.GetStandardInteractionButton())
        //{
            if (hand.GetStandardInteractionButtonDown())
            {
                // Save our position/rotation so that we can restore it when we detach
                //oldPosition = transform.position;
                //oldRotation = transform.rotation;

                // Call this to continue receiving HandHoverUpdate messages,
                // and prevent the hand from hovering over anything else
                hand.HoverLock(GetComponent<Interactable>());

                // Attach this object to the hand
                hand.AttachObject(gameObject, attachmentFlags);
            OnMenuAttached.Invoke();
            }
            else if(hand.GetStandardInteractionButtonUp())
            {
                // Detach this object from the hand
                hand.DetachObject(gameObject);

                // Call this to undo HoverLock
                hand.HoverUnlock(GetComponent<Interactable>());

                // Restore position/rotation
                //transform.position = oldPosition;
                //transform.rotation = oldRotation;
            }
        //}
    }


    //-------------------------------------------------
    // Called when this GameObject becomes attached to the hand
    //-------------------------------------------------
    private void OnAttachedToHand(Hand hand)
    {
        //textMesh.text = "Attached to hand: " + hand.name;
        attachTime = Time.time;
    }


    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {
        //textMesh.text = "Detached from hand: " + hand.name;
    }
}
