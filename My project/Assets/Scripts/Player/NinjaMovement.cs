using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class NinjaMovement : MonoBehaviour

{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

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

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, moveDirection.y * MovementSpeed);
    }

}
