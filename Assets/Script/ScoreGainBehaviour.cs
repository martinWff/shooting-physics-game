using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGainBehaviour : MonoBehaviour
{
    [SerializeField] int score;
    public void GainScore()
    {
        FindObjectOfType<GameManager>().AddScore(score);
    }
}
