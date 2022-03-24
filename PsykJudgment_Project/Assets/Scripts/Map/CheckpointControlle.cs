using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControlle : MonoBehaviour
{
    public static CheckpointControlle instance;
    public Checkpoint [] arrayCheckpoints;

    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        arrayCheckpoints = FindObjectsOfType<Checkpoint>(); //Rellenamos el array

        spawnPoint = CharacterController2D.instance.transform.position;
    }

    public void DeactivateCheckPoints() //Apagamos todos los sprites
    {
        foreach (Checkpoint checkpoint in arrayCheckpoints)
        {
            checkpoint.ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)//Generamos la posición del nuevo spawnPoint
    {
        spawnPoint = newSpawnPoint;
    }
}
