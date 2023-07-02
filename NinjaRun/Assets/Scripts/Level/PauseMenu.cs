using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Autor: Paul

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Wenn ESC gedrückt wurde
        {
            if (GameIsPaused) //Das Spiel ist Pausiert
            {
                Resume(); //Spiel geht wieder los
            }
            else //Das Spiel läuft 
            {
                Pause(); //Spiel wird pausiert 
            }
        }
    }
    public void Resume() //pausiert Spiel indem timeScale auf 0 gesetzt wird
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause() //setzt Spiel fort indem timeScale auf 1 gesetzt wird
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame() //man kommt ins Hauptmenu zurück 
    {
        SceneManager.LoadScene(0);
    }
}
