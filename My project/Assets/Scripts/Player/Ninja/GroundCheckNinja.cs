using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckNinja : MonoBehaviour
{
    public static bool groundCheckNinja = false;
    public static bool groundCheckRonin = false;


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ninja")) groundCheckNinja = true;

        if (collider.gameObject.CompareTag("Ronin")) groundCheckRonin = true;
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ninja")) groundCheckNinja = false;

        if (collider.gameObject.CompareTag("Ronin")) groundCheckRonin = false;
    }
}
