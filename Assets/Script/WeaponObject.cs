using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponObject : ScriptableObject
{
    public float damage;
    public float reloadingTime;
    [Tooltip("the total amount of bullets the player has")] public int defaultMaxAmmo;

    [Tooltip("the maximum amount of bullets fitting in 1 reload")] public int magazineAmmoCount;

    public GameObject bulletPrefab;

    public WeaponSoundCollectionObject sounds;

}
