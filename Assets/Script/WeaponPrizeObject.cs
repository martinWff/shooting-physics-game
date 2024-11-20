using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prizes/WeaponPrizeObject")]

public class WeaponPrizeObject : PrizeObject
{
    public WeaponObject weapon;

    public override string GetPrizeText()
    {
        return string.Format(prizeText, weapon.name);
    }

    public override void Reward(GameObject instigator)
    {
        instigator.GetComponentInChildren<Weapon>().weaponObject = weapon;
    }
}
