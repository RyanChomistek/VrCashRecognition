using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CashInputController : MonoBehaviour
{
    public int currentAmount;
    public TextMeshPro text;

    private void OnTriggerEnter(Collider other)
    {
        var currency = other.GetComponent<Currency>();
        if (currency)
        {
            currentAmount += currency.Amount;

            var otherHostObject = other.transform.parent.gameObject;

            FindObjectsOfType<Hand>().ForEach(x => 
            {
                if(x.currentAttachedObject == otherHostObject)
                {
                    x.DetachObject(otherHostObject);
                    x.HoverUnlock(otherHostObject.gameObject.GetComponent<Interactable>());
                }
            }
            );

            Destroy(otherHostObject);
            // Detach this object from the hand
            //hand.DetachObject(other.transform.parent.gameObject);

            // Call this to undo HoverLock
            //hand.HoverUnlock(other.transform.parent.gameObject.GetComponent<Interactable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var currency = other.GetComponent<Currency>();
        if (currency)
        {
            currentAmount -= currency.Amount;
        }
    }
}

