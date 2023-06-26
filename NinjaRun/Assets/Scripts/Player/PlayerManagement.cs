using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    public GameObject looserScreen;
    public GameObject winnerScreen;

    private void Start()
    {
        FireWall.fireWallBool = false;
        Time.timeScale = 1f;
        looserScreen.SetActive(false);
    }

    private void Update()
    {
        if (FireWall.fireWallBool == true) Death();

        if (Pokal.finished == true) Finished();
    }


    public void Death()
    {
        Time.timeScale = 0f; //Setzt Zeit auf Null -> Man kann sich nicht mehr bewegen
        looserScreen.SetActive(true);
    }

    public void Finished ()
    {
        Time.timeScale = 0f; //Setzt Zeit auf Null -> Man kann sich nicht mehr bewegen
        winnerScreen.SetActive(true);
        StartCoroutine(waiter());
    }

    IEnumerator waiter() //Erzeugung des Waiters
    {
        yield return new WaitForSecondsRealtime(5f);
        LevelAccess.level = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(0);
    }
}
