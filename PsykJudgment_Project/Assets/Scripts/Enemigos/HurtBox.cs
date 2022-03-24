using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HurtBox : MonoBehaviour
{
    public GameObject deathEffect;
    public float chanceToDrop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print(gameObject.name);
        if (other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);

            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            //PlayerController.instance.Bounce();
        }
    }
}
