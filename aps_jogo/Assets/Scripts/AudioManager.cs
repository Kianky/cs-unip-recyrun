using System; // Usado para criar Array
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {

        foreach (Sound s in sounds)
        { // Código que faz criar fontes de audio para todos os audios do jogo
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    public void Play(string nome)
    {  // Método para fazer tocar um audio em qualquer script
        Sound s = Array.Find(sounds, sound => sound.nome == nome);
        s.source.Play();
    }
}