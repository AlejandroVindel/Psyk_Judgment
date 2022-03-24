using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialogo", fileName = "uwu")]
public class Dialogue : ScriptableObject
{
    public Persona[] persona;
    public Enunciado[] dialogos;
}

[System.Serializable]
public class Enunciado
{
    public int indiceHablante;
    public string dialogo;
}

[System.Serializable]
public class Persona
{
    public string nombre;
    public Sprite fotito;
}