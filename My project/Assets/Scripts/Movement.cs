using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class PlayerMovement : MonoBehaviour

{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    public Rigidbody2D _rigidbody;

    public PlayerInput playerMovement;
    private InputAction move;

    private void Awake()
    {
        playerMovement = new PlayerInput();
    }
    private void OnEnable()
    {
        move = playerMovement.Player.Move;
    }
    private void OnDisable()
    {
        move.Disable();
    }

    void Start()

    {

        _rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()

    {

        var movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;



        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)

        {

            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        }

    }

}
