using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Written by Quinn
//This uses Unity Events
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
    }

    public void MOVE(InputAction.CallbackContext context)
    {
        Debug.Log("Move buttom was pressed" + context.phase);

        if (context.performed != false)
        {
            //Movement code
            //This may need to be changed out of the rigidbody and into transform. 
            Vector2 inputVector = context.ReadValue<Vector2>();
            playerRigidbody.AddForce(new Vector2(inputVector.x, inputVector.y) * speed);
        }

        //If the button press was canceled
        if (context.canceled != false)
        {

        }
    }
}

