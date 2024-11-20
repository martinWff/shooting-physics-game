using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrizeBehaviour : MonoBehaviour
{
    public PrizeLootTable prizeTable;

    public int chanceOfNoReward = 5;

    // Start is called before the first frame update
    public void Run()
    {
        if (prizeTable != null)
        {
            int count = prizeTable.prizeCount;
            int index = Random.Range(0, count+ chanceOfNoReward);
            PrizeObject prize = prizeTable.GetByIndex(index);
            if (prize != null)
            {
                FindObjectOfType<GameManager>().Reward(prize);
            }
        }
    }

}
