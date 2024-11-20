using UnityEngine;

public abstract class PrizeObject : ScriptableObject
{
    [SerializeField] protected string prizeText;

    public abstract string GetPrizeText();

    public abstract void Reward(GameObject instigator);
}
