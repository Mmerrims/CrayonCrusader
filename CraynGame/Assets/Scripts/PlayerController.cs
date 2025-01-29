//Written by Quinn
//This uses Unity Events
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    public float speed;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        PlayerControls playerControls = new PlayerControls();
        playerControls.Player1.Enable();
    }

    public void MOVE(InputAction.CallbackContext context)
    {
        Debug.Log("Move buttom was pressed" + context.phase);
        //If the button was pressed
        if(context.performed != false)
        {
            //Movement Code. May need to be moved out of rigidbody and into transform
            Vector2 inputVector = context.ReadValue<Vector2>();
            playerRigidbody.AddForce(new Vector2(inputVector.x, inputVector.y) * speed);
        }

        //If the button press was canceled
        if(context.canceled != false)
        {

        }
    }

    private void OnDestroy()
    {
        //These are vestigal. 
        //playerControls.Player1.Move1.performed -= Move1_performed;
        //playerControls.Player1.Move1.canceled -= Move1_canceled;
    }
}
