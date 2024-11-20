using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisController : MonoBehaviour
{

    [SerializeField] GameObject debrisObject;
    [SerializeField] Rigidbody rb;


    public void Destroy()
    {
        Instantiate(debrisObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void OnImpact()
    {
        rb.AddRelativeForce(Vector3.up * 10, ForceMode.Impulse);
    }
}
