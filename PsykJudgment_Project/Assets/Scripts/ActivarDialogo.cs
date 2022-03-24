using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDialogo : MonoBehaviour
{
    public Dialogue dialogo;
    public float distancia = 2f;
    public Transform jugador;

    private bool dialogoActivado = false;
    private void Update()
    {
        if ((jugador.position - transform.position).sqrMagnitude < distancia * distancia)
        {
            if (!dialogoActivado)
            {
                AparecerTexto.pulsaE.Appear();
                dialogoActivado = true;
            }

            if (Input.GetButtonDown("Interact"))
            {
                DialogueManager.instance.dialogue = dialogo;
                DialogueManager.instance.StartText();
            }
        }
        else
        {
            if (dialogoActivado)
            {
                dialogoActivado = false;
                AparecerTexto.pulsaE.Disappear();
            }
        }
    }
}
