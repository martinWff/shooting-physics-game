using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Weapon : MonoBehaviour
{
    [Tooltip("the ammount of bullets in the weapon")]public int ammo;


    public int totalAmmo;

    private float currentCooldown;


    [Tooltip("the transform where the bullet will be instantiated")]public Transform barrel;

    public WeaponObject weaponObject;

    public UnityEvent onShoot;
    public UnityEvent<int> onReload;

    public AudioSource audioSource;

    public GameObject flash;

    private void Start()
    {
        totalAmmo = weaponObject.defaultMaxAmmo;
    }

    public void LoadWeaponObject(WeaponObject weaponObject)
    {
        this.weaponObject = weaponObject;
        totalAmmo = weaponObject.defaultMaxAmmo;
        currentCooldown = 0;
        ammo = weaponObject.magazineAmmoCount;
    }


    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;

        }
    }

    public float GetCurrentCooldown()
    {
        return currentCooldown;
    }

    public void Fire()
    {
        if (ammo > 0 && currentCooldown <= 0)
        {
            GameObject prefab = Instantiate(weaponObject.bulletPrefab, barrel.position, barrel.rotation);
            ProjectileBehaviour projectile = prefab.GetComponent<ProjectileBehaviour>();
            projectile.damage = weaponObject.damage;
            projectile.Throw(100);
            Destroy(prefab, 10);
            ammo--;
            if (onShoot != null)
            {
                onShoot.Invoke();
            }

            if (audioSource != null)
            {
                AudioClip audio = GetShootAudio();
                if (audio != null)
                {
                    audioSource.clip = audio;
                    audioSource.Play();
                }
            }
            if (flash != null)
            {
                GameObject effect = Instantiate(flash, barrel.position, Quaternion.identity);
                Destroy(effect, 5);
            }
        }

    }

    protected AudioClip GetShootAudio()
    {
        WeaponSoundCollectionObject weaponSoundCollection = weaponObject.sounds;
        if (weaponSoundCollection != null)
        {
            int index = Random.Range(0, weaponSoundCollection.soundCount);
            return weaponSoundCollection.GetSoundByIndex(index);

        }
        return null;
    }

    protected AudioClip GetReloadAudio()
    {
        WeaponSoundCollectionObject weaponSoundCollection = weaponObject.sounds;
        if (weaponSoundCollection != null)
        {

            return weaponSoundCollection.reloadClip;
        }
        return null;
    }


    public void Reload()
    {
        if (totalAmmo > 0)
        {
            int exchange = Mathf.Min(weaponObject.magazineAmmoCount, totalAmmo);

            ammo = exchange;

            totalAmmo -= exchange;

            currentCooldown = weaponObject.reloadingTime;

            if (audioSource != null)
            {
                AudioClip clip = GetReloadAudio();
                if (clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                }
            }

            if (onReload != null)
            {
                onReload.Invoke(exchange);
            }
        }
    }

    public void RefillAmmo()
    {
        totalAmmo = weaponObject.defaultMaxAmmo;
        ammo = weaponObject.magazineAmmoCount;
        if (onReload != null)
        {
            onReload.Invoke(weaponObject.magazineAmmoCount);
        }
    }
}
