using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Audio : MonoBehaviour{

    public AudioClip[] sonidosUI = new AudioClip[5];
    //Sonidos: 0= start_button; 1 = cursor_vertical; 2 = cursor_horzontal; 3 = a_button; 4 = x_button;
    static AudioClip[] static_sonidosUI = new AudioClip[5];
    void Start()
    {
        static_sonidosUI = sonidosUI;
    }
    public static void ReproducirSonido (int numeroSonido, GameObject objeto)
    {
        
        if(!objeto.GetComponent<AudioSource>())
        {
            objeto.AddComponent<AudioSource>();
        }

        AudioSource audioSource = objeto.GetComponent<AudioSource>();
        audioSource.clip = static_sonidosUI[numeroSonido];
        audioSource.Play();
    }
}
