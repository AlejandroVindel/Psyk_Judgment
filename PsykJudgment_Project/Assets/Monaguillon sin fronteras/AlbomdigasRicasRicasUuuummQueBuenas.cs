using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbomdigasRicasRicasUuuummQueBuenas : MonoBehaviour
{
    public Boss bossreference;


    public float vidaMax;
    public float vidaAct;

    private void Start()
    {
        vidaAct = vidaMax;
    }
    public void ApplyDamage(float damage)
    {
        if (bossreference == null)
        {
            Destroy(gameObject);
            return;
        }

        vidaAct -= damage;

        if (vidaAct < 0)
        {
            Destroy(gameObject);
            bossreference.almondigaMuerta();
        }

        bossreference.ApplyDamage(damage);
    }
}
