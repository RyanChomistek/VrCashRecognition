using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
    public class LightSwitch : MonoBehaviour
    {
        public UnityEvent onSwitchActivated;
        public UnityEvent onSwitchDeactivated;

        public bool IsActivated = false;

        public void Activate()
        {
            Debug.Log("assadsadsadad");
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown())
            {
                if(!IsActivated)
                {
                    onSwitchActivated.Invoke();
                }
                else
                {
                    onSwitchDeactivated.Invoke();
                }

                IsActivated = !IsActivated;
            }
        }
    }
}
