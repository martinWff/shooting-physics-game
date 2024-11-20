using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prizes/DamagePrizeObject")]
public class DamagePrizeObject : PrizeObject
{
    public float damageValue;

    public override string GetPrizeText()
    {
        return string.Format(prizeText,damageValue);
    }


    public override void Reward(GameObject instigator)
    {
        if (instigator == null)
            return;
        instigator.GetComponent<IDamageable>().TakeDamage(damageValue);
    }
}
