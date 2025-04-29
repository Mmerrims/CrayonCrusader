using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public GameObject hitObject;
    [SerializeField] private PlayerController playerController;
    private bool canHitButton = true;
    private float buttonCooldown = 1f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lever") != false)
        {
            //Debug.Log("Lever has been hit");
            hitObject = collision.gameObject;
            Debug.Log(canHitButton);

            hitObject.GetComponent<Lever>().GetOpenClose();
        }

        else if (collision.CompareTag("Player") && collision.GetComponent<PlayerCollision>().canGetHit != false)
        {
            //Debug.Log("Attack hit a player");
            hitObject = collision.gameObject;
            hitObject.GetComponent<PlayerCollision>().PlayerControllerHit();
            playerController.PlayerHurt();
        }
        else if (collision.CompareTag("RotationButton") != false)
        {
            Debug.Log("Rotation button hit");
            hitObject = collision.gameObject;
            //hitObject.GetComponent<Rotate>().RotateObject();

        }

    }




}
