using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int gemmsCollected;

    public GameObject audio1;
    public GameObject audio2;

    private void Awake()
    {
        instance = this;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
        CharacterController2D.instance.canDash = true;
        Attack.instance.canAttack = true;
        
        if (audio2.GetComponent<AudioSource>().isPlaying)
        {
            audio2.GetComponent<AudioSource>().Pause();
            audio1.GetComponent<AudioSource>().Play();
        }
        ActivarBoss.instance.boss.enabled = false;
    }

    IEnumerator RespawnCo()//Las corrutinas nos permiten esperar segundos y ejecutar un código
    {
        
        CharacterController2D.instance.gameObject.SetActive(false);//Desactivamos al jugador
        yield return new WaitForSeconds(waitToRespawn);//Esperamos los segundos que le ayamos indicado
        CharacterController2D.instance.gameObject.SetActive(true);//Activamos al jugador
        
        CharacterController2D.instance.transform.position = CheckpointControlle.instance.spawnPoint;//Lo llevamos al checkPoint

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.masxHealth;//Reseteamos las vidas al máximo
        UIController.instance.UpdateHealthDisplay();

    }
}
