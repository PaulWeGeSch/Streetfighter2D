using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Paul + Lukas(animationen)

public class Frog : MonoBehaviour
{
    public float speed; 
    public int direction = 1; //Richtung des Frosches

    public GameObject frog;

    // Update is called once per frame
    private void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        Vector2 frogMovement = new Vector2(direction, 0); //Richtung der Geschwindigkeit des Frosches
        transform.Translate(frogMovement * Time.deltaTime * speed); //Initialisierung der Frosch Geschwindigkeit
    }


    //Frisch soll die Richtung ändern wenn er die Wand berührt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FrogWall")) direction = direction * -1;
    }

    //Speigelt den Frosch wenn er die Richtung wechselt
    private void Flip() 
    {
        if (direction == -1) transform.localScale = new Vector3(-5.979726f, 6.055514f, 1.4685f);

        if (direction == 1) transform.localScale = new Vector3(5.979726f, 6.055514f, 1.4685f);
    }
}
