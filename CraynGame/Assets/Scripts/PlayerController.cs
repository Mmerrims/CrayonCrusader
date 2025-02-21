//Written by Quinn
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private float speed = 3.5f;
    [SerializeField] public bool isMoving;
    [SerializeField] private GameObject attackZone;
    private float dirX;
    private float dirY;
    [SerializeField] private float attackDuration;

    [SerializeField] private GameObject runningClip;

    private GameManager gameManager;

    
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    //This moves the player. It is invoked by Unity Events
    public void MOVE(InputAction.CallbackContext context)
    {
        Debug.Log("Move button was pressed" + context.phase);
        //If the button was pressed
        if (context.performed != false)
        {
            //Movement Code. May need to be moved out of rigidbody and into transform
            Vector2 inputVector = context.ReadValue<Vector2>();
            playerRigidbody.velocity = new Vector2(inputVector.x, inputVector.y) * speed;
            isMoving = true;

            //Moves the attack zone
            attackZone.transform.position = new Vector3(playerRigidbody.transform.position.x + ((1.25f * inputVector.x) / 2), playerRigidbody.transform.position.y + ((1.25f * inputVector.y) / 2), 0f);


        }

        //If the button press was canceled
        if (context.canceled != false)
        {
            playerRigidbody.velocity = new Vector2(0, 0) * speed;
            isMoving = false;

        }
    }
    public void Slice(InputAction.CallbackContext context)
    {
        if(context.performed != true) 
        {
            Debug.Log("Slice Occured");
            attackZone.SetActive(true);
            StartCoroutine(attack());
        }
    }

    private IEnumerator attack()
    {
        Debug.Log("CoROutine started");
        yield return new WaitForSeconds(attackDuration);
        Debug.Log("Attack duration ended");
        attackZone.SetActive(false);
    }


    private void OnDestroy()
    {
        //Currently empty. Just keeping this here so I don't forget when we 
        //eventually need to add stuff here. 
    }

    void Update()
    {
        if (isMoving == true)
        {
            runningClip.SetActive(true);
        }
        else
        {
            runningClip.SetActive(false);
        }
    }
}
