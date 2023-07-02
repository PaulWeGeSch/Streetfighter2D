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
        t.text = PlayerPrefs.GetInt("Money", 0).ToString();
    }
    public void AddBlueD()
    {
        money++;
        PlayerPrefs.SetInt("Money", money);
    }
    public void AddGreenD()
    {
        money = money + 5;
        PlayerPrefs.SetInt("Money", money);
    }
    public void AddPinkD()
    {
        money = money + 10;
        PlayerPrefs.SetInt("Money", money);
    }
}
