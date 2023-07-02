using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Autor: Paul

public class LevelAccess : MonoBehaviour
{
    static public int level = 1; //globale Variable für den aktuellen Level Stand der für den Spieler spielbar ist

    //jede play Methode ist dem jeweiligem Button im Menu zugeordnet
    public void playLevel1()
    {
        if (level >= 1) SceneManager.LoadScene(1); //Scene 1 wird geladen
    }
    public void playLevel2()
    {
        if (level >= 2) SceneManager.LoadScene(2); //Scene 2 wird geladen
    }
    public void playLevel3()
    {
        if (level >= 3) SceneManager.LoadScene(3); //Scene 3 wird geladen
    }
}
