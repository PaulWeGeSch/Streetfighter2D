using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
            Debug.Log("j");

        }

        //Bewegung nach oben
        if (rb.velocity.y > 0 && isJumping) 
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

            //Animation Springen
            
            if (animator.GetInteger("Airstate") == 0)                // Wenn Ninja in der Luft fällt er
            {
                animator.SetInteger("Airstate", 1);
                Debug.Log("Animiert Absprung");
            }

        }

        //lässt springen los
        if (Input.GetButtonUp("Jump")) 
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
            
        }

        //fällt
        if (rb.velocity.y < 0) 
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.fixedDeltaTime;

            //Animation Fallen

            if (animator.GetInteger("Airstate") == 1)                 // Wenn Ninja in der Luft, schaut ob er springt, dann verzögert fällt er
            {
                animator.SetInteger("Airstate", 2);
                Debug.Log("Animiert Fallen");
            }

        }
       
    }
    
    //Update() übernimmt animationen
    private void Update()
    {
        Groundcheck();
        if (isGrounded == false)
        {
            //animator.SetBool("jump", true);
            //if (Movment.move.y > 0) animator.SetFloat("yVelocity", 1);
            
            //else animator.SetFloat("yVelocity", -1);
        }
        else
        {
            //animator.SetBool("jump", false);
            //animator.SetFloat("yVelocity", 0);
        }
           
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
