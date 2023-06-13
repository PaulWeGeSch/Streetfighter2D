using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class NinjaMovement : MonoBehaviour

{
    public float MovementSpeed = 1;
    public float JumpForce = 10;
    bool m_FacingRight = true;
    float yDirection;

    public Animator animator;

    public Collider2D groundCheck;
    

    public Rigidbody2D rb;
    Vector2 moveDirection = Vector2.zero;

    public PlayerInput playerMovement;
    private InputAction move;

    private void Awake()
    {
        playerMovement = new PlayerInput();
    }
    private void OnEnable()
    {
        move = playerMovement.Ninja.MoveNinja;
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()

    {
        moveDirection = move.ReadValue<Vector2>();
        //jumpDirection = move.ReadValue
        
       
        
        if (moveDirection.x > 0.01)  // Frägt Geschwindigkeit ab, wenn sich Ninja bewegt startet die Run-Animation 
        {
            animator.SetBool("Run", true);

            if (!m_FacingRight) Flip();
        }
        else
        {
            if (moveDirection.x < -0.01)
            {
                animator.SetBool("Run", true);

                if (m_FacingRight) Flip();
            }
            else
            {
                animator.SetBool("Run", false);
            }
        }

        if (GroundCheckNinja.groundCheckNinja == false && (animator.GetInteger("Airstate") == 0))                // Wenn Ninja in der Luft fällt er
        {
            animator.SetInteger("Airstate", 2);
        }

        if (GroundCheckNinja.groundCheckNinja == false && (animator.GetInteger("Airstate") == 1))                 // Wenn Ninja in der Luft schaut ob er springt dann verzögert fällt er
        {
           // Timer muss irgendwie rein für eine Sekunde
            animator.SetInteger("Airstate", 2);
        }


        if (GroundCheckNinja.groundCheckNinja == true)                  // Wenn Ninja auf dem Boden State "0"
        {
            animator.SetInteger("Airstate", 0);
        }

        if (GroundCheckNinja.groundCheckNinja == true && Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("springt");
            //moveDirection.y wird nicht ausgeslesen. Ist immer 0
            //rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);  // + 10 den Wert für Animationstest

            rb.velocity = new Vector2(0 , moveDirection.y * JumpForce);

            animator.SetInteger("Airstate", 1);                        // Wenn Ninja springt startet Springanimation
            Debug.Log("Animiert");
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, 0);

       
        //Debug.Log(moveDirection.y);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
