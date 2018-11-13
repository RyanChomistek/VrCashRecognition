using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
    public class CheckoutButtonController : MonoBehaviour
    {
        public bool IsActivated = false;

        public void Activate()
        {
            Debug.Log("assadsadsadad");
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown())
            {
                if(CashMachineController.Instance.AmountLeft == 0)
                {
                    //Debug.Log("good to go " + CashMachineController.Instance.AmountChange);
                    PreviousScoresController.Instance.AddPrevScore(CashMachineController.Instance.AmountChange * 10 + (int) TimerController.Instance.time);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
