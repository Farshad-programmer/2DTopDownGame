using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D theRb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool facingLeft = false;
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        playerControls = new PlayerControls();
        theRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        anim.SetFloat("moveX",movement.x);
        anim.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        theRb.MovePosition(theRb.position + movement * (moveSpeed * Time.fixedDeltaTime));

    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mosePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if(mosePos.x < playerScreenPoint.x)
        {
            spriteRenderer.flipX = true;
            FacingLeft = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            FacingLeft = false;
        }
    }


    // getter and setter in one line
    
     public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }

    
}
