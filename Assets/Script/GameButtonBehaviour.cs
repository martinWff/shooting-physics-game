using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameButtonBehaviour : MonoBehaviour, IInteracteable
{
    public UnityEvent<GameObject> onPressed;
    public void Interact(GameObject instigator)
    {
        if (onPressed != null)
        {
            onPressed.Invoke(instigator);
        }
    }
}
