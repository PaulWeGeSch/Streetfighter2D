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
    public void AddBlueD() //Wert für blauer Diamand (1) wird Money hinzugefügt
    {
        money++;
        PlayerPrefs.SetInt("Money", money); //Money wird zu Speicher hinzugefügt
    }
    public void AddGreenD() //Wert für grüner Diamand (5) wird Money hinzugefügt
    {
        money = money + 5;
        PlayerPrefs.SetInt("Money", money); //Money wird zu Speicher hinzugefügt
    }
    public void AddPinkD() //Wert für pinker Diamand (10) wird Money hinzugefügt
    {
        money = money + 10;
        PlayerPrefs.SetInt("Money", money); //Money wird zu Speicher hinzugefügt
    }
}
