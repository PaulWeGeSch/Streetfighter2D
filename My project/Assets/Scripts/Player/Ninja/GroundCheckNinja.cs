using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckNinja : MonoBehaviour
{
    public static bool groundCheckNinja = false;
    public static bool groundCheckRonin = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ninja")) groundCheckNinja = true;

        if (collision.gameObject.CompareTag("Ronin")) groundCheckRonin = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ninja")) groundCheckNinja = false;

        if (collision.gameObject.CompareTag("Ronin")) groundCheckRonin = false;
    }
   

    /**
    private void Update()
    {
        Debug.Log(groundCheckNinja);
    }
    **/
}
