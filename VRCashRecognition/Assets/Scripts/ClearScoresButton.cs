using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PreviousScoresController))]
public class ClearScoresButton : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PreviousScoresController myScript = (PreviousScoresController)target;

        if (GUILayout.Button("Clear Scores"))
        {
            myScript.ClearScores();
        }
    }
}
