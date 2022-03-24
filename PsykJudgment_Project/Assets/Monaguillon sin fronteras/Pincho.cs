using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincho : MonoBehaviour
{
    public float desplazamiento = 3;
    public float tiempoDeAparecer = .2f;
    public float tiempoDeMorirme = 1f;

    BoxCollider2D collider;
    private void Start()
    {
        Invoke(nameof(aparecer), tiempoDeAparecer);
        collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.enabled = false;
    }
    

    private void aparecer()
    {
        transform.position += Vector3.up * desplazamiento;
        Invoke(nameof(desaparecer), tiempoDeMorirme);
        collider.enabled = true;
    }

    private void desaparecer()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
}
