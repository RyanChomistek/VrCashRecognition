using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

namespace Valve.VR.InteractionSystem
{
    public class CheckoutButtonController : MonoBehaviour
    {
        public bool IsActivated = false;
        public GameObject LoadNextSceneButton;
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
                    int score = CashMachineController.Instance.AmountChange * 10 + (int)TimerController.Instance.time;
                    PreviousScoresController.Instance.AddPrevScore(score);

                    LoadNextSceneButton.SetActive(true);
                    LoadNextSceneButton.GetComponentInChildren<TextMeshPro>().text = $"Your score was : {score}. \n Press here to restart.";
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
