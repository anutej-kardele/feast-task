using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 inputValue;
    [SerializeField] private bool runValue;

    private MovementInput inputActions;
    private Rigidbody rb;
    [SerializeField] private float movementSpeed = 5, runspeed = 10; 

    private void Awake(){
        inputActions = new MovementInput();
        rb = GetComponent<Rigidbody>();
    }

    private void Start(){
        EventManager.gameOver += OnGameOver;
    }

    private void OnEnable(){
        inputActions.Enable();
        inputActions.Movement.Movement.performed += OnMovementPerformed;
        inputActions.Movement.Movement.canceled += OnMovementCancelled;

        inputActions.Movement.Run.performed += OnMovementRun;
        inputActions.Movement.Run.canceled += OnMovementRun;
    }

    private void OnMovementRun(InputAction.CallbackContext context)
    {
        runValue = (context.ReadValue<float>() == 0) ? false : true;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
        inputValue = Vector2.zero;
    }

    
    private Vector3 move;

    public void FixedUpdate(){
        move = new Vector3(inputValue.x, 0, inputValue.y);

        // is RunValue is active then multiple with run speed or else with movement speed 
        rb.velocity = move * (runValue ? runspeed : movementSpeed);

        transform.forward = move;
    }

    public void OnGameOver(){
        inputValue = Vector2.zero;
        Destroy(this);
    }
}
