//Script para los enemigos que andan

using UnityEngine;

public class EnemigoAnda : MonoBehaviour
{
    public float velocidad = 2f;                                                           //Velocidad del enemigo
    readonly float velMaxCaida = -25f;     
    
    public Rigidbody2D rb;
    public Transform player;
    public float distanciaDelJugador;
    public float rangoDeVision;
    public GameObject deathEffect;
    Enemigo enemigo;																//Referencia al componente enemigo

    void Start()
    {
        enemigo = GetComponent<Enemigo>();											//Asignamos el componente Enemigo a la variable enemigo
    }

    void FixedUpdate()
    {
        distanciaDelJugador = Vector2.Distance(player.position, rb.position);

        if (distanciaDelJugador <= rangoDeVision)
        {
            Movimiento();
            Caida();
        }
    }

    void Movimiento()
    {
        if (enemigo.muerto == true)													//Si el enemigo está muerto, salimos
            return;

        if (Mathf.Abs(enemigo.rb.velocity.x) < 0.01f)										//Si el enemigo choca
            velocidad = -velocidad;													//Cambiamos su velocidad a la contraria

        if (velocidad > 0)															//Si el enemigo lleva velocidad positiva
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1f);						//Giramos su sprite (Mira a la derecha)
        }
        if (velocidad < 0)															//Si el enemigo lleva velocidad negativa
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1f);							//Ponemos su sprite original (Mira a la izquierda)
        }

        enemigo.rb.velocity = new Vector2(velocidad, enemigo.rb.velocity.y);						//Guardamos la velocidad en el rigidBody
    }

    public void Caida()
    {
        if (enemigo.rb.velocity.y < velMaxCaida)                                            //Comprobamos si caemos demasiado rápido
            enemigo.rb.velocity = new Vector2(enemigo.rb.velocity.x, velMaxCaida);                  //Ajustamos la velocidad en Y al máximo permitido
    }
    
    public void ApplyDamage(float damage)
    {
        print("DAÑIO");
        Instantiate(deathEffect);
        Destroy(gameObject);   
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
}