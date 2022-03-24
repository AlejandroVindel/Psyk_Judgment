using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuego : MonoBehaviour
{

    private Rigidbody2D rb;
    private float initialHeight;
    public float force = 10;
    public float timeToJump = 1;
    private float gravityScale = 1;
    public float initialJumpTime = 0;
    private bool jumping = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialHeight = transform.position.y;
        gravityScale = rb.gravityScale;

        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        Invoke(nameof(Jump), initialJumpTime);
    }

    private void Update()
    {
        if(transform.position.y < initialHeight && !jumping)
        {
            jumping = true;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
            Invoke(nameof(Jump), timeToJump);
        }
    }

    void Jump()
    {
        jumping = false;
        rb.gravityScale = gravityScale;
        rb.velocity = Vector2.up * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController2D>())
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
}
