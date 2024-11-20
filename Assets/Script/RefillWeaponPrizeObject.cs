using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prizes/RefillWeaponPrizeObject")]
public class RefillWeaponPrizeObject : PrizeObject
{
    public override string GetPrizeText()
    {
        return prizeText;
    }

    public override void Reward(GameObject instigator)
    {
        Weapon weapon = instigator.GetComponentInChildren<Weapon>();
        if (weapon != null)
        {
            weapon.RefillAmmo();
        }
    }
}
