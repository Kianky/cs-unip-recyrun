using UnityEngine;
[System.Serializable] // Usado para permitir a inserção de Array a partir do inspetor do Unity
public class Sound
{
    public string nome;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
}