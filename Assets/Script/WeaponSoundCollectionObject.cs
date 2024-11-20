using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponSoundCollectionObject : ScriptableObject
{
    public AudioClip reloadClip;

    public AudioClip[] shootClips;


    public int soundCount { get {
        if (shootClips == null)
            {
                return 0;
            }

            return shootClips.Length;
        
        } }

    public AudioClip GetSoundByIndex(int index) {
        
        if (shootClips != null && shootClips.Length > index)
        {
            return shootClips[index];
        }

        return null;
    }
  
}
