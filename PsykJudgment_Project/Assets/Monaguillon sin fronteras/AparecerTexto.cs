using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AparecerTexto : MonoBehaviour
{
    public static AparecerTexto pulsaE;

    public float velocidadAparicion = 0.1f;

    private Text text;

    public int idx = 0;
    private void Awake()
    {
        pulsaE = this;
        text = GetComponent<Text>();
        text.text = "";
    }
    Coroutine corrutinaActual = null;
    public void Appear()
    {
        if (corrutinaActual != null)
            StopCoroutine(corrutinaActual);
        corrutinaActual = StartCoroutine(aparecer());
    }

    public void Disappear()
    {
        if (corrutinaActual != null)
            StopCoroutine(corrutinaActual);
        corrutinaActual = StartCoroutine(desaparecer());
    }

    private const string mensaje = "Pulsa E o el panel para hablar";
    private IEnumerator aparecer()
    {
        for(; idx < mensaje.Length; idx++)
        {
            text.text += mensaje[idx];
            yield return new WaitForSeconds(velocidadAparicion);
        }
    }

    private IEnumerator desaparecer()
    {
       
        while(text.text.Length > 0)
        {
            text.text = text.text.Remove(text.text.Length - 1);
            idx = text.text.Length;
            yield return new WaitForSeconds(velocidadAparicion);
        }
    }
}
