using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Autor: Paul

public class Looserscreen : MonoBehaviour
{
    public void BackToMenu() //Wenn Knopf gedr�ckt wird dann kommt man ins Hauptmenu zur�ck
    {
        SceneManager.LoadScene(0);
    }
    public void StartAgain() //Wenn Knopf gedr�ckt wird dann startet das Level erneut
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
