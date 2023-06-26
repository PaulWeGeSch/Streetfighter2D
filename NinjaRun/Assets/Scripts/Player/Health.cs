using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static float playerHealth = 100f;    //Leben des Spielers

    public PlayerManagement pm; //Referenz zum PlayerManagment Script; Man muss das Objekt mit dem Passendem Script in das Feld vom Inspektor ziehen
    public Frog frog;

    //Updates jeden Frame
    private void Update()
    {
        //Wenn der Spieler keine Leben mehr hat soll er mit der Death funktion aus Playermanagement sterben
        if(playerHealth <= 0)
        {
            pm.Death();
        }
    }

    //Funktion wird gecalled wenn das Objekt ein anderes ber�hrt
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Wenn der Spieler einen Frosch ber�hrt soll ihm Leben abgezogen werden und der Frosch soll sich vom Spieler wegdrehen
        if (collision.gameObject.CompareTag("Frog"))
        {
            playerHealth = playerHealth - 20;
            frog.direction = frog.direction * -1;
        }
        //Wenn der Spieler den Kopf eines Frosches ber�hrt dann soll der Frosch zerst�rt werden
        if (collision.gameObject.CompareTag("FrogHead"))
        {
            Destroy(collision.gameObject);
        }
    }
}
