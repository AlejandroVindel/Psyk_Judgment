using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//La pabraba Joystick es el nombre del script
public class Joystick : MonoBehaviour
{

    //Se declara el movimiento que tendrá el objeto
    public float speed = 2;
    //Se declara la dirección donde ira a la derecha positiva o izquierda negativa
    public Vector2 direction;


    /// <summary>
    /// 
    /// SCRIPT PARA MOVER UN OBJETO CON UN JOYSTICK
    /// 
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /// <summary>
        /// 
        /// Ejemplo de como se moveria un objeto con solo las dos variables declaras, no hace parte, pero sirve
        /// para saber como se moveria a la derecha e izquerda. Se puede modificar y ver en el objeto.
        /// </summary>
        /*

        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);


        if (horizontal < 0f || horizontal > 0f)
        {
            Debug.Log("Work" + horizontal);


             Vector2 movements = direction.normalized * speed * Time.deltaTime;
             transform.Translate(movements);


        }
  */

        //Se declaran que Axes tomaremos con el nombre que le pusismos, estos manejaran los lados y arriba y abajo.*
        float horizontal = Input.GetAxis("JoyStickHorz");
        float vertical = Input.GetAxis("JoyStickVert");
        

        //Se declara el componente que vamos a modificar, en este caso la dirección y esta se encuentra píblica
        //En el mismo script, por lo tanto tomaremos su GetComponent
        Joystick New = GetComponent<Joystick>();

        //Hacemos un if para saber que estamos leyendo, en este caso leemos cuando se pulsa el stick a la izquierda
        //y nos lee el axes de Horizontal o JoyStickHorz como se llama.
        if (horizontal < 0f)
        {
            //Se hace una comprobación por consola
            Debug.Log("Se mueve a la:" + horizontal);
            //Se cambia la dirección
            New.direction.x = -1;

            //Se agrega el movimiento con la dirección, la velocidad y el delta time*
            Vector2 movements = direction.normalized * speed * Time.deltaTime;
            //Hacemos una transformación al objeto y le aplicamos la función Translate para desplazarlo.
            transform.Translate(movements);
        }
        //IMPORTANTE: Por ultimo se agrega un 0 a la dirección cuando ya no se oprime, ya que al dejar la misma dirección
        //El objeto todavia tiene en x una dirección que se cambia cuando el eje y cambia. Haciendo que se desplaze de forma diagonal.
        else
        {
            New.direction.x = 0;
        }

        // Lo mismo pero cuando se oprime a la derecha del JoyStick
        if (horizontal > 0f)
        {
            Debug.Log("Se mueve a la:" + horizontal);


            New.direction.x = 1;

            Vector2 movements = direction.normalized * speed * Time.deltaTime;
            transform.Translate(movements);
        }
        else
        {
            New.direction.x = 0;
        }

        //Ahora se hace con los negativos del eje y
        if (vertical < 0f)
        {
            Debug.Log("Se mueve a la:" + vertical);
            New.direction.y = 1;

            Vector2 movements = direction.normalized * speed * Time.deltaTime;
            transform.Translate(movements);
        }
        else
        //IMPORTANTE: Por ultimo se agrega un 0 a la dirección cuando ya no se oprime, ya que al dejar la misma dirección
        //El objeto todavia tiene en y una dirección que se cambia cuando el eje x cambia. Haciendo que se desplaze de forma diagonal.

        {
            New.direction.y = 0;
        }

        if (vertical > 0f)
        {
            Debug.Log("Se mueve a la:" + vertical);


            New.direction.y = -1;

            Vector2 movements = direction.normalized * speed * Time.deltaTime;
            transform.Translate(movements);


        }
        else
        {
            New.direction.y = 0;
        }

        if (Input.GetKey(KeyCode.JoystickButton16)) {

            Debug.Log("Se mueve a la:" + vertical);

        }

    }
}
