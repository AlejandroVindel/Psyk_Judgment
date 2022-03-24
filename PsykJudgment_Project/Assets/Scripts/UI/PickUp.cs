using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isGem, isHeal;
    private bool isCollected;
    public GameObject pickUpEffect;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemmsCollected++;
                
                UIController.instance.UpdateGemCount(); //Para aumentar la cuenta del UI

                Instantiate(pickUpEffect, transform.position, transform.rotation);//Instanciamos el pickUpEffect
                
                isCollected = true;
                
                audio.Play();
                GetComponent<SpriteRenderer>().enabled = false;
                    
                Invoke(nameof(Destruir),2);
            }else if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.masxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    audio.Play();
                    GetComponent<SpriteRenderer>().enabled = false;
                    
                    Invoke(nameof(Destruir),2);
                }
            }
        }
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}
