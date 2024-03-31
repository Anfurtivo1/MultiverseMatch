using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Opcionesmanager : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    public void changeVolumenMaster(float slidervalue)
    {
        Debug.Log("Valor es: " + slidervalue);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(slidervalue) * 20);
    }

    public void changeVolumenMusica(float slidervalue)
    {
        audioMixer.SetFloat("MusicaVolume", Mathf.Log10(slidervalue) * 20);
    }

    public void changeVolumenFX(float slidervalue)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(slidervalue) * 20);
    }
}
