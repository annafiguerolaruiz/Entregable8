using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class AudioManager : MonoBehaviour
{
    //Lista de canciones
    public AudioClip[] ClipArray;
    public string[] NombreDeLaCancion;
    public int CancionSonando;
    private AudioSource AudioManagerAudioSource;

    //Titulos de las canciones  
    public TextMeshProUGUI TituloDeLaCancion;
    // Start is called before the first frame update
    void Start()
    {
        AudioManagerAudioSource = GetComponent<AudioSource>();
        AudioManagerAudioSource.PlayOneShot(ClipArray[CancionSonando]);

    }

    // Update is called once per frame
    void Update()
    {
        TituloDeLaCancion.text = NombreDeLaCancion[CancionSonando];
    }

    //Boton NEXT cancion
    public void Next()
    {
        CancionSonando++;
        if (CancionSonando > ClipArray.Length)
        {
            CancionSonando = 0;
        }
        //Si pasa a la siguiente cancion, la que suena actualmente se detiene
        AudioManagerAudioSource.Stop();
        //Cancion actual

    }
    //Cancion anterior
    public void Back()
    {
        CancionSonando--;
        //Despues de la utima cancion, vuelve a la primera. Y despues de la ultima, vuelve a sona la primera.
        if (CancionSonando < 0)
        {
            CancionSonando = ClipArray.Length - 1;
        }
        //Cuando NEXT, la cancion actual se detiene para pasar a la siguiente
        AudioManagerAudioSource.Stop();
        //Cancion actual
        AudioManagerAudioSource.PlayOneShot(ClipArray[CancionSonando]);
    }
    //Boton PAUSA
    public void Pausa()
    {
        AudioManagerAudioSource.Pause();
    }
    //Boton Play
    public void Play()
    {
        AudioManagerAudioSource.UnPause();
    }
    //Boton cancion aleatoria
    public void Aleattorio()
    {
        AudioManagerAudioSource.Stop();
        CancionSonando = Random.Range(0, ClipArray.Length);
        AudioManagerAudioSource.PlayOneShot(ClipArray[CancionSonando]);
    }
}















