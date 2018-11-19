using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class LoadNextSceneButton : MonoBehaviour {
    public bool IsActivated = false;

    public void Activate()
    {
        Debug.Log("assadsadsadad");
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown())
        {
            if (CashMachineController.Instance.AmountLeft == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
