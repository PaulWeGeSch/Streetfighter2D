using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class NinjaMovement : MonoBehaviour

{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

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

        //Debug.Log(GroundCheckNinja.groundCheckNinja);

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, 0);
        

        if (GroundCheckNinja.groundCheckNinja == true && Input.GetKeyDown("w"))
        {
            Debug.Log(moveDirection.y);                                                     //moveDirection.y wird nicht ausgeslesen. Ist immer 0
            rb.velocity = new Vector2(0, moveDirection.y * JumpForce);

            Debug.Log("springt");
        }


    }

}
