using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public int speed;
    public static bool fireWallBool = false;

    void Update()
    {
        Vector2 pace = new Vector2(1, 0);
        transform.Translate(pace * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("DEATH");
            fireWallBool= true;
        }
    }
}
