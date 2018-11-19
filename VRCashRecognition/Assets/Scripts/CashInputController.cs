using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CashInputController : MonoBehaviour
{
    public int currentAmount;
    public TextMeshPro text;
    public delegate void OnCashInputDelegate();

    [HideInInspector]
    public event OnCashInputDelegate OnCashInput;

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
                    OnCashInput.Invoke();
                    hand.DetachObject(otherHostObject);
                    hand.HoverUnlock(otherHostObject.GetComponent<Interactable>());
                    Destroy(otherHostObject);
                    return;
                }
            }
            );
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

