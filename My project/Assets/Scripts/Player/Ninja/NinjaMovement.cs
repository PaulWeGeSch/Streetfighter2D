using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class NinjaMovement : MonoBehaviour

{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    [SerializeField] bool isGrounded;
    public Transform groundcheckCollider;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public GameObject GroundCheck;
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

        Debug.Log(isGrounded);

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, 0);

        if (isGrounded == true && Input.GetKeyDown("w"))
        {
            rb.velocity = new Vector2(0, moveDirection.y * JumpForce);

            Debug.Log("springt");
        }


    }

    //checkt ob er auf dem Boden Steht
    void Groundcheck()                              //Groundcheck hat fehler -> immer false
    {
        isGrounded = false;

        //ein capsule collider wird unter ihm generriert
        Collider2D[] colliders = Physics2D.OverlapCapsuleAll(groundcheckCollider.position, new Vector2(1.5f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        // Wenn er dieser den Boden breührt ist "isGrounded" true
        if (colliders.Length > 0) isGrounded = true;

    }

}
