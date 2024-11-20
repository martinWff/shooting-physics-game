using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public float walkSpeed;

    float horizontal;
    float vertical;
    bool isJumping;
    public float jumpStrength;

    [SerializeField]Transform floorDetection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            isJumping = true;
        }

    }

    bool OnGround()
    {

        return Physics.Raycast(floorDetection.position,Vector3.down, 1);
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            // Vector3 v = new Vector3(horizontal,0, vertical) * walkSpeed * Time.deltaTime;

            Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
            moveDirection = moveDirection.normalized * walkSpeed;


            moveDirection.y = rb.velocity.y;

            rb.velocity = moveDirection;
            if (isJumping)
            {
                rb.AddForce(Vector2.up * jumpStrength, ForceMode.Impulse);
                isJumping = false;
            }

        }

    }
}
