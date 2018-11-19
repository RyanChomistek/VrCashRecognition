using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PreviousScoresController : MonoBehaviour {

    [Serializable]
    public class Scores
    {
        public List<int> scores;
    }

    public static PreviousScoresController Instance;

    public GameObject PreviousScoreCardPrefab;
    
	// Use this for initialization
	void Start () {
        ReloadPrevScores();

        if (Instance)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }

    public void AddPrevScore(int score)
    {
        string json = PlayerPrefs.GetString("prevScores");
        var scores = JsonUtility.FromJson<Scores>(json);
        scores.scores.Add(score);
        string newJson = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("prevScores", newJson);
    }

    public void ReloadPrevScores()
    {
        Debug.Log("asdasdasd");
        if (PlayerPrefs.HasKey("prevScores"))
        {
            string json = PlayerPrefs.GetString("prevScores");
            var scores = JsonUtility.FromJson<Scores>(json);
            Debug.Log("scores " + json);
            scores.scores.Reverse();
            //foreach ( var score in scores.scores)
            for(int i = 0; i < scores.scores.Count && i < 10; i++)
            {
                var score = scores.scores[i];
                var card = Instantiate(PreviousScoreCardPrefab);
                card.GetComponent<TextMeshProUGUI>().text = "" + score;
                card.transform.SetParent(transform, false);
            }
        }
        else
        {
            Debug.Log("empty scores");
            ClearScores();
        }
    }

    public void ClearScores()
    {
        var scores = new Scores();
        scores.scores = new List<int>();
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("prevScores", json);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
