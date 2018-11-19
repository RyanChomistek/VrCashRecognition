using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Valve.VR.InteractionSystem;
using System;
using UnityEngine.UI;

public enum TutorialPrompEvent
{
    OnCurrencyAttach,
    OnCurrencyInsert,
    OnMenuMoved,
    OnVisionChanged,
    OnLightSwitched,
    OnEyeRingUsed
}

public class TutorialPromptController : MonoBehaviour {

    [Serializable]
    public class TutorialPrompDescriptionPair {
        public TutorialPrompEvent Event;
        public string Description;
    }

    public List<TutorialPrompDescriptionPair> Prompts;
    public Text DisplayText;
    public PlayerMenuController PlayerMenu;
	// Use this for initialization
	void Start () {
        var bills = FindObjectsOfType<CurrencyInteractable>().ToList();
        bills.ForEach(x => {
            Debug.Log(x.name);
            x.GetComponent<Interactable>().onAttachedToHand += OnCurrencyAttach;
            });
        FindObjectOfType<CashInputController>().OnCashInput += OnCashInputted;

        DisplayText.text = Prompts[0].Description;
        PlayerMenu.OnMenuAttached += OnMenuAttached;


        var lights = FindObjectsOfType<LightSwitch>().ToList();
        lights.ForEach(x => {
            x.onSwitchActivated.AddListener(OnLightSwitched);
        });

        var eyeRings = FindObjectsOfType<EyeRingController>().ToList();
        eyeRings.ForEach(x => {
            x.OnEyeringUsed += (() => OnEvent(TutorialPrompEvent.OnEyeRingUsed));
        });

        FindObjectOfType<VisionImpairmentSlider>().OnSliderChanged += (() => OnEvent(TutorialPrompEvent.OnVisionChanged));
    }

    void OnLightSwitched()
    {
        OnEvent(TutorialPrompEvent.OnLightSwitched);
    }

    void OnMenuAttached()
    {
        OnEvent(TutorialPrompEvent.OnMenuMoved);
    }

    void OnCashInputted()
    {
        OnEvent(TutorialPrompEvent.OnCurrencyInsert);
    }

    void OnCurrencyAttach(Hand hand)
    {
        Debug.Log("attach!");
        OnEvent(TutorialPrompEvent.OnCurrencyAttach);
    }

    private void OnEvent(TutorialPrompEvent tutorialEvent)
    {
        if(Prompts[0].Event == tutorialEvent)
        {
            GetNextPrompt();
        }
    }

    private void GetNextPrompt()
    {
        if(Prompts.Count == 1)
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log(Prompts.Count);
        Prompts.RemoveAt(0);
        DisplayText.text = Prompts[0].Description;

    }

}
