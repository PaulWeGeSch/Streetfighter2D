using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movment : MonoBehaviour
{
    static public Vector2 move;
    public int speed;
    public Animator animator;

    //public Animator animator;

    //private coinmanager m;

    void Start()
    {
        //m = GameObject.FindGameObjectWithTag("Text").GetComponent<coinmanager>();
    }

    private void Update()
    {
        
        move = new Vector2(1, Input.GetAxisRaw("Vertical")); 
        animator.SetFloat("speed", Mathf.Abs(move.x)); //lauf Animationen

        if (move.x > 0.01)  // Frägt Geschwindigkeit ab, wenn sich Ninja bewegt startet die Run-Animation 
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

            transform.Translate(move * speed * Time.deltaTime);

    }

    
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
