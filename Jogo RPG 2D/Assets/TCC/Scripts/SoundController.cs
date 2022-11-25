using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;

public class SoundController : MonoBehaviour
{
    public float volumeMusica = 0.271f;
    public float volumeEffects = 0.271f;


    public AudioSource musica;
    // Start is called before the first frame update
    void Start()
    {
        mudaVolumeMusica(volumeMusica);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mudaVolumeMusica(float valor) {

        volumeMusica = valor;
        musica.volume = valor;
        
    
    }
    public void mudaVolumeEfeitos(float valor) {
        volumeEffects = valor;
    }


}
