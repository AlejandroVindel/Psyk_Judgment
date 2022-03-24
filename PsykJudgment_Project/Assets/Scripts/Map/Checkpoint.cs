using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite cpOn, cpOff;

    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            CheckpointControlle.instance.DeactivateCheckPoints(); //Apagamos todos los sprites anteriores
            theSR.sprite = cpOn;//Si el jugador toca el Sprite se enciende
            CheckpointControlle.instance.SetSpawnPoint(transform.position);//Llamamos a la funcion para pasarle la nueva posición de checkPoint
            
            
        }
    }

    public void ResetCheckpoint() //Metodo que resetea los checkpoints
    {
        theSR.sprite = cpOff;
    }
}
