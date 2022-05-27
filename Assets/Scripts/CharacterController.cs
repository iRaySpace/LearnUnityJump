using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    [SerializeField]
    private UnityEvent jumpTrigger;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool hasJumped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y > 0) 
        {
            anim.SetBool("isJumping", true);
        } else 
        {
            anim.SetBool("isJumping", false);
        }

        if (rb.velocity.x != 0)
        {
            anim.SetBool("isWalking", true);
        } else 
        {
            anim.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float velocityX = horizontalInput * speed;

        bool jumpInput = Input.GetButton("Jump");
        float velocityY = rb.velocity.y;
        if (jumpInput && !hasJumped)
        {
            velocityY = jumpForce;
            hasJumped = true;
            jumpTrigger.Invoke();
        }

        rb.velocity = new Vector2(velocityX, velocityY);

        if (rb.velocity.y < 0)
        {
            hasJumped = false;
        }

        // TODO: should not be able to jump if not grounded
    }

    void LateUpdate()
    {
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
