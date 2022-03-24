using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohete : MonoBehaviour
{
    public float speed;
    public float steeringSpeed = 10;

    public Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 dir  = ((Vector2)player.position - rb.position).normalized;

        float rotateAmount = Vector3.Cross(dir, transform.right).z;

        rb.angularVelocity = -rotateAmount * steeringSpeed;
        rb.velocity = transform.right * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerHealthController.instance.DealDamage();
        }
    }

    public void ApplyDamage(float damage)
    {
        Destroy(gameObject);   
    }
}
