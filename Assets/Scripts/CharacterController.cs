using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool hasJumped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     print(horizontalInput);
    // }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float velocityX = horizontalInput * speed;

        bool jumpInput = Input.GetButton("Jump");
        float velocityY = rb.velocity.y;
        if (jumpInput && !hasJumped) {
            velocityY = jumpForce;
            hasJumped = true;
        }

        rb.velocity = new Vector2(velocityX, velocityY);

        if (rb.velocity.y < 0) {
            hasJumped = false;
        }

        // TODO: should not be able to jump if not grounded
    }
}
