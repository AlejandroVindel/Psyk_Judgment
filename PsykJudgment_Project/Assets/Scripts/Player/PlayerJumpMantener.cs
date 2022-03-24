using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerJumpMantener : MonoBehaviour
{
    private RaycastHit2D hit;
    public float gravedad;
    public float alturaSalto;
    public Animator anim;
    
    [Header("Grounded")] 
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private void FixedUpdate()
    {
        Detector_Plataforma();
        Jump();
        transform.Translate(transform.up * gravedad * Time.fixedDeltaTime);
    }

    //Detectamos si el jugador está en una plataforma o no
    public void Detector_Plataforma()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround); //Detectamos si el jugador toca el suelo o no

        if (isGrounded)
        {
            alturaSalto = 0;
            gravedad = 0;
            anim.SetBool("Jump",false);
        }
        else
        {
            anim.SetBool("Jump",true);
            gravedad = -3f;
        }
    }
    
    //Le damos al jugador la función de saltar
    public void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (alturaSalto < 0.5f)
            {
                alturaSalto += 1 * Time.deltaTime;// * Time.deltaTime para que no afecten los frames al movimiento
                gravedad = 8;
            }
        }
        else
        {
            alturaSalto = 1f;
        }
    }
}
