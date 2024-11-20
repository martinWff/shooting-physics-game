using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            if (Cursor.lockState == CursorLockMode.None) {
                Cursor.lockState = CursorLockMode.Locked;
            } else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }


    public void SetCursorLock(bool state)
    {
        Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
