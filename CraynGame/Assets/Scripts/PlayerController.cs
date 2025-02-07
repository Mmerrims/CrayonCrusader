//Written by Quinn
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    //Two copies of this script are needed. One for each player. 
    [SerializeField] private string team;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float speed;

    private GameManager gameManager;

    
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    //This moves the player. It is invoked by Unity Events
    public void MOVE(InputAction.CallbackContext context)
    {
        Debug.Log("Move buttom was pressed" + context.phase);
        //If the button was pressed
        if (context.performed != false)
        {
            //Movement Code. May need to be moved out of rigidbody and into transform
            Vector2 inputVector = context.ReadValue<Vector2>();
            playerRigidbody.AddForce(new Vector2(inputVector.x, inputVector.y) * speed);
        }

        //If the button press was canceled
        if (context.canceled != false)
        {
            playerRigidbody.AddForce(new Vector2(0, 0) * speed);

        }
    }
    public void Slice(InputAction.CallbackContext context)
    {
       Ray ray = new Ray(playerRigidbody.position, transform.forward);
        Debug.DrawRay(playerRigidbody.position, transform.forward);
        Debug.Log("Sliced");
    }


    private void OnDestroy()
    {
        //Currently empty. Just keeping this here so I don't forget when we 
        //eventually need to add stuff here. 
    }

}
