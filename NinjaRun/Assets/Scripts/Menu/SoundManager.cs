using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSilder;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {

        }
    }
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
