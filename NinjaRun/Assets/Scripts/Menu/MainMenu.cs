using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Beendet das Spiel
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
