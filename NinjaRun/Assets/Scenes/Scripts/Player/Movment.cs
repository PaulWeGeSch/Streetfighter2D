using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    static public Vector2 move;
    public int speed;

    //public Animator animator;

    //private coinmanager m;

    void Start()
    {
        //m = GameObject.FindGameObjectWithTag("Text").GetComponent<coinmanager>();
    }

    private void Update()
    {
        
        move = new Vector2(1, Input.GetAxisRaw("Vertical")); 
        //animator.SetFloat("speed", Mathf.Abs(move.x)); //lauf Animationen
       
        transform.Translate(move * speed * Time.deltaTime);

    }

    //Spiegelt den Spieler achsensymetrisch zur mittleren X-Achse wenn er nach links/rechts läuft
    
    /**
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cherry")
        {
            m.AddCoin();
            Destroy(other.gameObject);
        }
    }
    **/
   

}
