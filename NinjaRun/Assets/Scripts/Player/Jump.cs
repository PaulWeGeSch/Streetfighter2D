using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor: Paul + Lukas

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Jump System")]
    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpMultiplier;
    


    public Transform groundcheckCollider;
    public LayerMask groundLayer;

    Vector2 vecGravity;
    
    bool isJumping;
    float jumpCounter;
    [SerializeField] bool isGrounded;

    public Animator animator;
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        

        //springt ab
        if (Input.GetButtonDown("Jump") && isGrounded == true)  // Spieler ist auf dem Boden und drückt die Springen-Taste
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
            Debug.Log("j");

        }

        //Bewegung nach oben
        if (rb.velocity.y > 0 && isJumping)   // Der Spieler bewegt sich gerade nach oben, soll aber nicht unendlich weit fliegen, deshalb wird die Gravitation mit der Zeit erhöht
        {
            
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpMultiplier / jumpTime;
            float currentJumpM = jumpMultiplier;

            if(t > 0.5)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;

                   }

        //lässt springen los
        if (Input.GetButtonUp("Jump"))  // Spieler erfährt keine Kraft nach oben mehr
        {
            
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
            
        }

        //fällt 
        if (rb.velocity.y < 0)              // Der Spieler fällt immer schneller
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.fixedDeltaTime;
           
           
        }
       
    }
    
    //Update() übernimmt Animationen
    private void Update()
    {
        
        Groundcheck();
        if (isGrounded == false)
        {
            //animator.SetBool("jump", true);
            if (Movment.move.y > 0) animator.SetInteger("Airstate", 1); // hebt ab / bewegt sich nach oben (Animation)
            
            if (Movment.move.y <= 0) animator.SetInteger("Airstate", 2); // fällt / bewegt sich nach unten (Animation)
        }
        else
        {
            //animator.SetBool("jump", false);
            animator.SetInteger("Airstate", 0);   // Läuft ganz normal / ist auf dem Boden (Animation)
        }
        //Debug.Log(rb.velocity.y);
        //Debug.Log(Movment.move.y);
    }
    
    //checkt ob er auf dem Boden Steht
    void Groundcheck()
    {
        isGrounded = false;

        //ein capsule collider wird unter ihm generriert
        Collider2D[] colliders = Physics2D.OverlapCapsuleAll(groundcheckCollider.position, new Vector2(1.5f, 0.3f),CapsuleDirection2D.Horizontal, 0, groundLayer);

        // Wenn er dieser den Boden breührt ist "isGrounded" true
        if (colliders.Length > 0) isGrounded = true;

    }
}
