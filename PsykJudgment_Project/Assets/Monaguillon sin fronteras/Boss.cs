using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Rigidbody2D player;

    public GameObject pincho;
    public GameObject cohete;
    public GameObject almondiga;

    private float health = 100;
    public float groundLevel = 0;

    public float lowHealthTime = .3f;
    public float highHealthTime = 3;

    private int numerodealbondigas = 0;

    public Slider barradevida;

    public float tiempoEntreAlmondigas = 10f;
    private float timerAlmondiga = 0;

    public GameObject puerta;
    private void Start()
    {
        barradevida.maxValue = health;
        barradevida.value = barradevida.maxValue;
    }
    private float timeBetweenAtacks()
    {
        return Mathf.Lerp(lowHealthTime, highHealthTime, health / 100f);
    }

    private float timer = 0;
    private float nextAttack = 5;
    private void Update()
    {
        timerAlmondiga += Time.deltaTime;

        if ((timer += Time.deltaTime) > nextAttack)
        {
            timer = 0;

            if (timerAlmondiga > tiempoEntreAlmondigas)
            {
                timerAlmondiga = 0;
                crearAlmondiga();
            }
            else
            {
                Attack();
            }
            nextAttack = timeBetweenAtacks();
        }
    }

    private void Attack()
    {
        float t = (health / 100f);

        int r = (int)Mathf.Floor(Random.value * 2);

        switch (r)
        {
            case 0:
                {
                    Cohete cc = Instantiate(cohete, transform.position + new Vector3(0, 5, 0), Quaternion.identity).GetComponent<Cohete>();
                    //cc.speed = Random.onUnitSphere * 10f;

                    cc.steeringSpeed = Mathf.Lerp(cc.steeringSpeed, cc.steeringSpeed * 3, t);
                    cc.transform.rotation = Quaternion.Euler(0, 0, 90);
                    cc.player = player.transform;
                }
                break;
            case 1:
                {
                    float x = player.position.x;
                    Vector3 pos = new Vector3(x, groundLevel);
                    Pincho pp = Instantiate(pincho, pos, Quaternion.identity).transform.GetChild(0).GetComponent<Pincho>();
                    pp.tiempoDeAparecer = Mathf.Lerp(0.3f, 1, t);

                    pp.transform.position += new Vector3(+Mathf.Lerp(0, player.velocity.x, t) * pp.tiempoDeAparecer * Random.value, 0, 0);
                }
                break;
            default:
                print("Algo salió mal");
                break;
        }
    }

    private void crearAlmondiga()
    {
        if (numerodealbondigas == 2)
        {
            Attack();
            return;
        }

        numerodealbondigas++;
        Vector2 position = transform.position + new Vector3(-8 + Random.value * 16, 10);
        AlbomdigasRicasRicasUuuummQueBuenas albomdigasRicasRicasUuuummQueBuenas = Instantiate(almondiga, position, Quaternion.identity).GetComponent<AlbomdigasRicasRicasUuuummQueBuenas>();
        albomdigasRicasRicasUuuummQueBuenas.vidaMax = 25f;
        albomdigasRicasRicasUuuummQueBuenas.bossreference = this;
    }

    public void ApplyDamage(float damage)
    {
        print(health);
        health -= damage;

        barradevida.value = health;

        if (health < 0)
        {
            Destroy(puerta);
            Destroy(gameObject);
        }
    }

    public void almondigaMuerta()
    {
        numerodealbondigas--;
    }
}
