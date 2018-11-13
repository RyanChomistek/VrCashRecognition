using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using System.Xml;
using System.IO;
using TMPro;

public class ReadText : MonoBehaviour {

    private SpVoice voice;

    private void Start()
    {
        voice = new SpVoice();
    }

    public virtual string GetText()
    {
        return "";
    }

    public void Read()
    {
        voice.Volume = 100; // Volume (no xml)
        voice.Rate = 0;  //   Rate (no xml)
        
        voice.Speak("<speak version='1.0' xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>"
                    + GetText()
                    + "</speak>",
                    SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
    }
}
