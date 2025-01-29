using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    public float speed;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        PlayerControls playerControls = new PlayerControls();
        
        playerControls.Player2.Enable();
        
        playerControls.Player2.Move2.performed += Move2_performed;
        playerControls.Player2.Move2.canceled += Move2_canceled;
    }

    private void Move2_canceled(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void Move2_performed(InputAction.CallbackContext context)
    {
        //Move code
        Vector2 inputVector = context.ReadValue<Vector2>();
        playerRigidbody.AddForce(new Vector2(inputVector.x, inputVector.y) * speed);
    }

    public void MOVE(InputAction.CallbackContext context)
    {
        Debug.Log("Move buttom was pressed" + context.phase);

        if (context.performed != false)
        {
            //Movement code goes here
            //playerRigidbody.AddForce();
        }
    }
}
