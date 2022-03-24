//Script común a todos nuestros enemigos

using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    int capaJugador;                                                                    //Variable para guardar el ID de la capa jugador

    public bool muerto = false;                                                         //Variable para saber si el enemigo está muerto
    int muertoID;                                                                       //ID del bool muerto en el animador
    Animator anim;
                                                                          //Referencia al Animador
    public Rigidbody2D rb;
    public float velocidad;
    public Transform player;
    public float velocidadDeReverse;
    public float rangoDeReverse;
    public float distanciaDelJugador;
    public float rangoDeVision;
    public float rangoDeDisparo;
    public GameObject deathEffect;
    

    private void Update()
    {
        distanciaDelJugador = Vector2.Distance(player.position, rb.position);

        if (distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReverse &&
            distanciaDelJugador > rangoDeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo, velocidad * Time.deltaTime);
            rb.MovePosition(nuevapos);

        }
        else if (distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReverse &&
                 distanciaDelJugador <= rangoDeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo,0);
            rb.MovePosition(nuevapos);
        }
        else if (distanciaDelJugador < rangoDeReverse)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevapos = Vector2.MoveTowards(rb.position, objetivo, velocidadDeReverse * Time.deltaTime);
            rb.MovePosition(nuevapos);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoDeVision);
        Gizmos.DrawWireSphere(transform.position, rangoDeDisparo);
        Gizmos.DrawWireSphere(transform.position, rangoDeReverse);
    }

    private void Start()
    {
        capaJugador = LayerMask.NameToLayer("Player");                                 //Obtenemos el ID de la capa

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();                                                //Asignamos el Animator del enemigo a la variable anim
        muertoID = Animator.StringToHash("muerto");                                        //Guardamos el ID de muerto en el animador
    }

    public void ApplyDamage(float damage)
    {
        print("DAÑIO");
        Instantiate(deathEffect);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
}