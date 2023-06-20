using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokal : MonoBehaviour
{
    public static bool finished = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finished");
            finished = true;
        }
    }
}
