using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float damage;
    [SerializeField]private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable;
        if (collision.gameObject.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.TakeDamage(damage);
        }
        Destroy(gameObject);

    }

    public void Throw(float strength)
    {
        rb.AddRelativeForce(Vector3.forward * strength, ForceMode.Impulse);
    }
}
