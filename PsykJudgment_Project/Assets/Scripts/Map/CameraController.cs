using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget; //Objeto que la camara va a seguir

    public Transform farBackground, middleBackGRound;

    public float minHeight, maxHeight;
    public float cameraSpeed = 1;

    private void Awake()
    {
        Vector3 target = new Vector3(followTarget.position.x, followTarget.position.y + 10, transform.position.z);
        transform.position = target;
    }

    void LateUpdate()
    {
        Vector3 target = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
        transform.position =
            Vector3.Lerp(transform.position, target, Time.deltaTime * cameraSpeed);
           ;//Hacemos que la cámara siga la posicion del jugador en la x y que la siga dentro de unos límites en la y
        
        if(farBackground)
        farBackground.position = new Vector3(transform.position.x, transform.position.y, farBackground.position.z); //Hacemos que el fondo se mueva con la cámara
        
        if(middleBackGRound)
        middleBackGRound.position = new Vector3(transform.position.x * .5f, transform.position.y * .5f, middleBackGRound.position.z); //El middleBackGround se mueve más lento
    }
}
