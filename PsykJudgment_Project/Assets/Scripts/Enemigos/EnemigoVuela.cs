//Este script controla el movimiento del enemigo que vuela

using UnityEngine;

public class EnemigoVuela : MonoBehaviour
{
    public bool horizontal;

    public float velocidad;
    public float longitud;

    float contador;
    float posicionInicial;
    float posicionActual;
    float posicionAnterior;

    Enemigo enemigo;

    void Start()
    {
        if (horizontal)																	//Si el movimiento del enemigo es horizontal
        {
            posicionInicial = transform.position.x;										//La posicion inicial es la de la X
        }
        else
        {
            posicionInicial = transform.position.y;										//Sino es la da la Y
        }

        enemigo = GetComponent<Enemigo>();												//Asignamos el componente Enemigo a la variable enemigo
    }

    void Update()
    {
        Volar();
    }

    void Volar()
    {
        if (enemigo.muerto == true)                                                 //Si el enemigo está muerto, salimos
            return;

        contador += Time.deltaTime * velocidad;

        if (horizontal)
        {
            transform.position = new Vector2(Mathf.PingPong(contador, longitud) + posicionInicial, transform.position.y);
            GirarEnemigo();
        }
        else
        {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(contador, longitud) + posicionInicial);
        }
    }

    void GirarEnemigo()
    {
        posicionActual = transform.position.x;
        if (posicionActual < posicionAnterior)
            transform.localScale = new Vector3(-2.5f, 2.5f, 1f);
        if (posicionActual > posicionAnterior)
            transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        posicionAnterior = transform.position.x;
    }
}