using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Paul + Lukas

public class FireWall : MonoBehaviour
{
    public int speed; //Geschwindigkeit der Wand
    public static bool fireWallBool = false;

    void Update()
    {
        Vector2 pace = new Vector2(1, 0); //Richtung der Wand
        transform.Translate(pace * speed * Time.deltaTime); //Initzialisierung der Geschwindigkeit
    }

    //Sobald der Spieler mit der Wand collidiert soll fireWallBool true sein
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fireWallBool= true;
        }
    }
}
