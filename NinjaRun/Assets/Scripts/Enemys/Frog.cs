using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float speed;
    public int direction = 1;

    public GameObject frog;


    private void Update()
    {
        Flip();
    }
    private void FixedUpdate()
    {
        Vector2 frogMovement = new Vector2(direction, 0);
        transform.Translate(frogMovement * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FrogWall")) direction = direction * -1;
    }

    private void Flip()
    {
        if (direction == -1) transform.localScale = new Vector3(-5.979726f, 6.055514f, 1.4685f);

        if (direction == 1) transform.localScale = new Vector3(5.979726f, 6.055514f, 1.4685f);
    }
}
