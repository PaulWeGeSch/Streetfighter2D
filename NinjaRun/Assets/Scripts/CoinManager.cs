using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int money;
    public Text t;

    // Start is called before the first frame update
    void Start()
    {
        money = PlayerPrefs.GetInt("Money", 0);
    }

    // Update is called once per frame
    void Update()
    {
        t.text = PlayerPrefs.GetInt("Money", 0).ToString(); //der Text wird auf den Wert von Money aus dem Speicher (PlayerPrefs) gesetzt
    }
    public void AddBlueD() //Wert f�r blauer Diamand (1) wird Money hinzugef�gt
    {
        money++;
        PlayerPrefs.SetInt("Money", money); //Money wird zu Speicher hinzugef�gt
    }
    public void AddGreenD() //Wert f�r gr�ner Diamand (5) wird Money hinzugef�gt
    {
        money = money + 5;
        PlayerPrefs.SetInt("Money", money); //Money wird zu Speicher hinzugef�gt
    }
    public void AddPinkD() //Wert f�r pinker Diamand (10) wird Money hinzugef�gt
    {
        money = money + 10;
        PlayerPrefs.SetInt("Money", money); //Money wird zu Speicher hinzugef�gt
    }
}
