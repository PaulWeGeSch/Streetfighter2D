using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class RoninMovement : MonoBehaviour

{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    bool m_FacingRight = false;

    public Rigidbody2D rb;
    Vector2 moveDirection = Vector2.zero;

    public Animator animator;

    public PlayerInput playerMovement;
    private InputAction move;

    private void Awake()
    {
        playerMovement = new PlayerInput();
    }
    private void OnEnable()
    {
        move = playerMovement.Ronin.MoveRonin;
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

        if (moveDirection.x > 0.01)  // Fr�gt Geschwindigkeit ab, wenn sich Ronin bewegt startet die Run-Animation 
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


        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, moveDirection.y * MovementSpeed);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
