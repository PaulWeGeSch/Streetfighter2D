using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokal : MonoBehaviour
{
    public static bool finished = false; //Boolean -> ist das Spiel beendet?

    //Wenn der Spieler mit dem Pokal in Kontakt kommt wird finished auf true gesetzt
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finished");
            finished = true; 
        }
    }
}
