using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Autor: Paul + Lukas

public class PlayerManagement : MonoBehaviour
{
    public GameObject looserScreen;
    public GameObject winnerScreen;

    private CoinManager m;


    //Beim Start von jeder Szene soll alles wieder auf die Ursprünglichen werte zurückgesetzt werden
    private void Start()
    {
        Health.playerHealth = 100f;
        FireWall.fireWallBool = false;
        DeathGround.deathGround = false;
        Time.timeScale = 1f;
        looserScreen.SetActive(false);
        Pokal.finished = false;
        winnerScreen.SetActive(false);

        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>(); //Sucht den CoinManager im Text Objekt um eine Refernz zu bilden
    }

    // Update is called once per frame
    // überprüft ob eine Variable die das Spiel beenden würde auf true ist und leitetet danach
    // entweder Finished() oder Death() ein
    private void Update()
    {
        if (FireWall.fireWallBool == true) Death();

        if (DeathGround.deathGround == true) Death();

        if (Pokal.finished == true) Finished();
    }

    // Die Funktion wird aufgerufen sobald der Spieler in Kontakt mit einem Trigger kommt
    // Hier: Trigger sind Münzen
    // Mpnzen sollen nach Kontakt zerstört werden und der zugehörige Wert soll zu Money hinzugefügt werden
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueD")) // der Trigger hat den Tag "BlueD"
        {
            Destroy(other.gameObject);
            m.AddBlueD(); 
        }
        if (other.gameObject.CompareTag("GreenD")) // der Trigger hat den Tag "GreenD"
        {
            Destroy(other.gameObject);
            m.AddGreenD();
        }
        if (other.gameObject.CompareTag("PinkD")) // der Trigger hat den Tag "PinkD"
        {
            Destroy(other.gameObject);
            m.AddPinkD();
        }
    }

    //Methode die aufgerufen wird sobald der Spieler stirbt
    public void Death()
    {
        Time.timeScale = 0f; //Setzt Zeit auf Null -> Man kann sich nicht mehr bewegen
        looserScreen.SetActive(true); // der looserscreeen soll sichtbar gemacht werden
    }

    //Methode die aufgerufen wird sobald der Spieler das Level beendet
    public void Finished ()
    {
        Time.timeScale = 0f; //Setzt Zeit auf Null -> Man kann sich nicht mehr bewegen
        winnerScreen.SetActive(true); // der winnerscreen soll scihtbar gemacht werden
        StartCoroutine(waiter()); //Verweis auf den Waiter() um Zeit abzuwarten
    }

    //Erzeugung des Waiters
    IEnumerator waiter() 
    {
        yield return new WaitForSecondsRealtime(5f); //5 Sekunden Pause
        LevelAccess.level = SceneManager.GetActiveScene().buildIndex + 1; //die Level Variable wird auf den Wert der Aktuellen Szene gesezt -> Spieler kann ein Level weiter
        SceneManager.LoadScene(0); // Das Hauptmenu wird geladen
    }
}
