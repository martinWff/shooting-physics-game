using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public int highestScore { get; private set; }

    [HideInInspector]public int lastScore;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool TrySetScore(int score)
    {
        int alteredScore = Mathf.Max(score, highestScore);

        bool state = alteredScore > highestScore;

        highestScore = alteredScore;

        lastScore = score;


        return state;
    }

    public void ResetData()
    {
        highestScore = 0;
        lastScore = 0;
        PlayerPrefs.DeleteKey("HighestScore");
    }

    public void LoadData()
    {
        TrySetScore(PlayerPrefs.GetInt("HighestScore", 0));
    }

}
