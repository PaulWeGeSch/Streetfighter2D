using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    public GameObject looserScreen;
    public GameObject winnerScreen;

    private CoinManager m;

    private void Start()
    {
        Health.playerHealth = 100f;
        FireWall.fireWallBool = false;
        DeathGround.deathGround = false;
        Time.timeScale = 1f;
        looserScreen.SetActive(false);
        Pokal.finished = false;
        winnerScreen.SetActive(false);

        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();
    }

    private void Update()
    {
        if (FireWall.fireWallBool == true) Death();

        if (DeathGround.deathGround == true) Death();

        if (Pokal.finished == true) Finished();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueD"))
        {
            Destroy(other.gameObject);
            m.AddBlueD();
        }
        if (other.gameObject.CompareTag("GreenD"))
        {
            Destroy(other.gameObject);
            m.AddGreenD();
        }
        if (other.gameObject.CompareTag("PinkD"))
        {
            Destroy(other.gameObject);
            m.AddPinkD();
        }
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
