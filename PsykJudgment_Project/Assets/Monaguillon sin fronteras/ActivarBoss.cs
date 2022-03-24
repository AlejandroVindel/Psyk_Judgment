using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ActivarBoss : MonoBehaviour
{
    public static ActivarBoss instance;
    public Boss boss;
    public GameObject audio1;
    public GameObject audio2;

    private void Awake()
    {
        instance = this;
        boss.enabled = false;
        boss.barradevida.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController2D>())
        {
            boss.enabled = true;
            boss.barradevida.gameObject.SetActive(true);
            
            audio1.GetComponent<AudioSource>().Pause();
            audio2.GetComponent<AudioSource>().Play();
        }
    }

}
