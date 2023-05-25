using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class NinjaMovement : MonoBehaviour

{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
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
        //Debug.Log(GroundCheckNinja.groundCheckNinja);

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, 0);

        if (GroundCheckNinja.groundCheckNinja == true && Input.GetKeyDown("w"))
        {
                                                              //moveDirection.y wird nicht ausgeslesen. Ist immer 0
            rb.velocity = new Vector2(0, yDirection * JumpForce);                 // + 10 den Wert für Animationstest

            Debug.Log("springt");
        }
        yDirection = moveDirection.y;
        Debug.Log(moveDirection.y);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
