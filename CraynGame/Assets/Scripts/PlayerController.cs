//Written by Quinn
//This uses Unity Events
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float speed;

    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        PlayerControls playerControls = new PlayerControls();
        playerControls.Player1.Enable();
    }

    //This moves the player. It is invoked by Unity Event
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
            playerRigidbody.AddForce(new Vector2(0,0) * speed);

        }
    }

    private void OnDestroy()
    {
        //Currently empty. Just keeping this here so I don't forget when we 
        //eventually need to add stuff here. 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
