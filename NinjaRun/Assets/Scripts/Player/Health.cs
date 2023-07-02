using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Autor: Paul

public class Health : MonoBehaviour
{
    public static float playerHealth = 100f;    //Leben des Spielers

    public PlayerManagement pm; //Referenz zum PlayerManagment Script; Man muss das Objekt mit dem Passendem Script in das Feld vom Inspektor ziehen

    public float KbSpeed; //Knockbackspeed bei Kontakt mit Frosch

    public Rigidbody2D rb; //Rigidbody des Spielers
    public Frog f; //Refernz zum Frosch

    public Image healthbar;

    //Updatetet jeden Frame
    private void Update()
    {
        //Wenn der Spieler keine Leben mehr hat soll er mit der Death funktion aus Playermanagement ausgef�hrt werden
        if(playerHealth <= 0)
        {
            pm.Death();
        }
        Debug.Log(playerHealth);
        healthbar.fillAmount = playerHealth / 100f; //die Health bar soll zu dem Prozentanteil des Lebens des Spielers gef�llt sein
    }

    //Funktion wird gecalled wenn das Objekt ein anderes ber�hrt
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Wenn der Spieler einen Frosch ber�hrt soll ihm Leben abgezogen werden und der Frosch soll sich vom Spieler wegdrehen
        if (collision.gameObject.CompareTag("Frog"))
        {
            playerHealth = playerHealth - 20f;
            f.direction = f.direction * -1; //Frosch dreht sich weg
        }
    }
}
