using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Newmove : MonoBehaviour
{
    private InputActions input;
    [Header("Movement")]
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Animator animator;

    private Vector2 movementVector = Vector2.zero;

    private Rigidbody2D rb;

    public GameObject shopPopup;
    private bool shopBool;

    public Shopkeeper sk;

    private void Awake()
    {
        input = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
   
    private void Update()
    {
        if (input.PlayerInput.Interact.triggered && shopBool==true)
        {
            sk.Interact();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movementVector.normalized * speed;

        float moveSpeed = movementVector.magnitude;
        animator.SetFloat("Speed", moveSpeed);
   
        if (movementVector.x > 0) 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movementVector.x < 0) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnEnable()
    {
        input.Enable();
        input.PlayerInput.Movement.performed += WhenMove;
        input.PlayerInput.Movement.canceled += MovementCanceled;
    }

    private void WhenMove(UnityEngine.InputSystem.InputAction.CallbackContext amount)
    {
        movementVector = amount.ReadValue<Vector2>();
    }

    private void MovementCanceled(UnityEngine.InputSystem.InputAction.CallbackContext amount)
    {
        movementVector = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shopkeeper"))
        {
            shopPopup.SetActive(true);
            shopBool = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shopkeeper"))
        {
            shopPopup.SetActive(false);
            shopBool = false;
        }
    }
}