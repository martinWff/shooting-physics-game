using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerBehaviour : MonoBehaviour, IInteracteable
{
    [SerializeField]private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void Interact(GameObject instigator)
    {
        animator.SetTrigger("Interact");
        Weapon weapon = instigator.GetComponentInChildren<Weapon>();
        if (weapon != null) {
            weapon.RefillAmmo();
        }

    }
}
