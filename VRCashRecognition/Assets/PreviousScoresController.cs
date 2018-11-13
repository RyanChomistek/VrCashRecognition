using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PreviousScoresController : MonoBehaviour {

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
        
        int numPrev = PlayerPrefs.GetInt("numPrev");
        PlayerPrefs.SetInt("prev " + numPrev, score);
        Debug.Log("saving " + ("prev " + numPrev) + " " + PlayerPrefs.GetInt("prev " + numPrev));

        numPrev++;
        PlayerPrefs.SetInt("numPrev", numPrev);
    }

    public void ReloadPrevScores()
    {
        if (PlayerPrefs.HasKey("numPrev"))
        {
            int numPrev = PlayerPrefs.GetInt("numPrev");
            for (int i = 0; i < numPrev; i++)
            {
                int prev = PlayerPrefs.GetInt("prev " + i);
                Debug.Log(prev);
                var card = Instantiate(PreviousScoreCardPrefab);
                card.GetComponent<TextMeshProUGUI>().text = "" + prev;
                card.transform.SetParent(transform, false);
            }
        }
        else
        {
            PlayerPrefs.SetInt("numPrev", 0);
        }
    }

    public void ClearScores()
    {
        PlayerPrefs.SetInt("numPrev", 0);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
