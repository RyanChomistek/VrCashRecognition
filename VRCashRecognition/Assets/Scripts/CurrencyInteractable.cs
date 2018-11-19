using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CurrencyInteractable : MonoBehaviour {
    private Vector3 oldPosition;
    private Quaternion oldRotation;

    private float attachTime;

    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown())
        {
            GetComponent<Rigidbody>().isKinematic = true;
            hand.HoverLock(GetComponent<Interactable>());

            // Attach this object to the hand
            hand.AttachObject(gameObject, attachmentFlags);
        }
        else if (hand.GetStandardInteractionButtonUp())
        {
            GetComponent<Rigidbody>().isKinematic = false;
            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(GetComponent<Interactable>());
        }
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
