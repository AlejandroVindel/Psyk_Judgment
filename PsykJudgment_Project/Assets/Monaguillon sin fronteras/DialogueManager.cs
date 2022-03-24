using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public float tiempoEntreLetras = 0.1f;
    public Text uiText;
    public Text nombre;
    public Image fondo;
    public GameObject pressToSkip;
    public PlayerMovement playerMovement;
    private bool activo = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = playerMovement.GetComponent<Rigidbody2D>();
        instance = this;
        fondo.gameObject.SetActive(false);
        pressToSkip.SetActive(false);
        //Invoke(nameof(StartText), 1);
    }

    bool skip = false;
    private void Update()
    {
        skip |= Input.GetButtonDown("Jump");
    }

    public Dialogue dialogue;
    public void StartText()
    {
        if (!activo) StartCoroutine(writeText());
    }

    private IEnumerator writeText()
    {
        rb.velocity = Vector2.zero;
        activo = true;
        playerMovement.enabled = false;
        fondo.gameObject.SetActive(true);
        for (int idx = 0; idx < dialogue.dialogos.Length; idx++)
        {
            Enunciado enunciado = dialogue.dialogos[idx];
            nombre.text = dialogue.persona[enunciado.indiceHablante].nombre;
            uiText.text = "";

            for (int letra = 0; letra < enunciado.dialogo.Length; letra++)
            {
                uiText.text += enunciado.dialogo[letra];

                if (!skip)
                    yield return new WaitForSeconds(tiempoEntreLetras);
            }

            skip = false;
            pressToSkip.SetActive(true);

            while (!skip)
            {
                yield return null;
            }
            pressToSkip.SetActive(false);
            skip = false;
        }

        fondo.gameObject.SetActive(false);
        playerMovement.enabled = true;

        activo = false;
    }


}
