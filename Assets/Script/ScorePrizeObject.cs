using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prizes/ScorePrizeObject")]
public class ScorePrizeObject : PrizeObject
{
    public int score;

    public override string GetPrizeText()
    {
        return string.Format(prizeText,score);
    }

    public override void Reward(GameObject instigator)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.AddScore(score);
        }
    }
}
