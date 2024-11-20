using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpawnerButton : MonoBehaviour, IInteracteable
{
    public Transform[] spawningLocations;

    public GameObject prefab;



    public void Interact(GameObject instigator)
    {
        if (spawningLocations == null)
            return;
        foreach (Transform target in spawningLocations)
        {
            Instantiate(prefab,target.position,Quaternion.identity);
        }


    }



}
