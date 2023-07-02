using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Paul

public class DeathGround : MonoBehaviour
{
    public static bool deathGround = false;

    //Wennd er Spieler von der Plattform f�llt und die DeathGrenze br�hrt soll deathGround true sein
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deathGround = true;
        }
    }
}
