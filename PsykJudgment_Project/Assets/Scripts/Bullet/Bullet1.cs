using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;
   
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    private SpriteRenderer myr;
    

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        myr = GetComponent<SpriteRenderer>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void Update()
    {
    }
        

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;

    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void Flip()
    {
        myr.flipX = !myr.flipX;
    }
}
