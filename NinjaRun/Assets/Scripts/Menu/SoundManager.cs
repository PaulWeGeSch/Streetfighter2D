using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Autor: Paul

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSilder;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) //wenn kein Wert für den Slider im Speicher gefunden wird, wird er auf 1 gesetzt
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
    }
    //Audio wird auf den Wert des Sliders gesetzt
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSilder.value;
        Save();
    }

    private void Save() //lädt Sound Einstellungen
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSilder.value);
    }
    private void Load() //Speichert Sopund Einstellungen
    {
        volumeSilder.value = PlayerPrefs.GetFloat("musicVolume");

    }
}
