using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUIController : MonoBehaviour
{
    string ammoTextLabel;
    [SerializeField]TextMeshProUGUI ammoLabel;
    [SerializeField]Image reloading;
    Weapon targetWeapon;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        targetWeapon = player.GetComponentInChildren<Weapon>();
        ammoTextLabel = ammoLabel.text;
        ReloadAmmoLabel();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading != null && targetWeapon.weaponObject != null && targetWeapon.weaponObject.reloadingTime != 0)
        {
            reloading.fillAmount = (targetWeapon.GetCurrentCooldown() / targetWeapon.weaponObject.reloadingTime);
        }
    }

    public void ReloadAmmoLabel()
    {
        ammoLabel.text = string.Format(ammoTextLabel, targetWeapon.ammo, targetWeapon.totalAmmo);
    }
}
