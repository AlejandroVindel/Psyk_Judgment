using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, masxHealth;

    public float invisibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;
    private void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        currentHealth = masxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
            Camera.main.GetComponent<ShaderManager>().Play();
            currentHealth--;
            CharacterController2D.instance.animator.SetBool("Hit", true);
            if(currentHealth <= 0) //Si no tenemos vidas borramos al jugador
            {
                currentHealth = 0;

                Instantiate(deathEffect, CharacterController2D.instance.transform.position, CharacterController2D.instance.transform.rotation);
                
                
                LevelManager.instance.RespawnPlayer();//Llamamos al método que hace respawn
                
            }
            else
            {
                invincibleCounter = invisibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                CharacterController2D.instance.knockback();

            }
        }
        //Metodo para borrar las vidas del UI
        UIController.instance.UpdateHealthDisplay();
    }
    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > masxHealth)
        {
            currentHealth = masxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}


