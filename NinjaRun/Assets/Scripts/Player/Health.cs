using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float playerHealth = 100f;    //Leben des Spielers

    public PlayerManagement pm; //Referenz zum PlayerManagment Script; Man muss das Objekt mit dem Passendem Script in das Feld vom Inspektor ziehen
    public Frog frog;
    public float KbSpeed;

    public Rigidbody2D rb;

    public Frog f;
    public Image healthbar;

    //Updates jeden Frame
    private void Update()
    {
        //Wenn der Spieler keine Leben mehr hat soll er mit der Death funktion aus Playermanagement sterben
        if(playerHealth <= 0)
        {
            pm.Death();
        }
        Debug.Log(playerHealth);
        healthbar.fillAmount = playerHealth / 100f;
    }

    //Funktion wird gecalled wenn das Objekt ein anderes ber�hrt
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Wenn der Spieler einen Frosch ber�hrt soll ihm Leben abgezogen werden und der Frosch soll sich vom Spieler wegdrehen
        if (collision.gameObject.CompareTag("Frog"))
        {
            playerHealth = playerHealth - 20f;
            f.direction = f.direction * -1;
        }
    }
}
