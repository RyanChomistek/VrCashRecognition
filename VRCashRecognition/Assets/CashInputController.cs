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

            FindObjectsOfType<Hand>().ForEach(hand => 
            {
                if(hand.currentAttachedObject == otherHostObject)
                {
                    //x.DetachObject(otherHostObject);
                    //x.HoverUnlock(otherHostObject.gameObject.GetComponent<Interactable>());
                    //x.GetComponent<Interactable>().onDetachedFromHand.;
                    //hand.DetachObject(otherHostObject);
                    //otherHostObject.GetComponent<Throwable>().PreventReattach = true;
                    //otherHostObject.transform.position = new Vector3(100000, 100000, 10000);
                    hand.DetachObject(otherHostObject);
                    hand.HoverUnlock(otherHostObject.GetComponent<Interactable>());
                    Destroy(otherHostObject);
                    //StartCoroutine(DestroyObject(otherHostObject));
                    return;
                }
            }
            );
            
            //Destroy(otherHostObject);

            // Detach this object from the hand
            //hand.DetachObject(other.transform.parent.gameObject);

            // Call this to undo HoverLock
            //hand.HoverUnlock(other.transform.parent.gameObject.GetComponent<Interactable>());
        }
    }

    IEnumerator DestroyObject(GameObject otherHostObject)
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Destroy(otherHostObject);
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

