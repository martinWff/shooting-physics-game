using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PrizeLootTable : ScriptableObject
{
    public List<PrizeObject> prizes = new List<PrizeObject>();

    public int prizeCount { get {
            if (prizes == null)
                return 0;
            return prizes.Count;

    } }

    public PrizeObject GetByIndex(int index)
    {
        if (prizes == null)
            return null;

        if (prizes.Count > index)
            return prizes[index];

        return null;
    }
}
