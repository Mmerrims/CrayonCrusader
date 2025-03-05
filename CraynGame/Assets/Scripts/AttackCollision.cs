using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    private GameObject hitObject;
    [SerializeField] private PlayerController playerController;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lever") != false)
        {
            //Debug.Log("Lever has been hit");
            hitObject = collision.gameObject;

            hitObject.GetComponent<Lever>().GetOpenClose();
        }

        else if (collision.CompareTag("Player") != false)
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
            hitObject.GetComponent<Rotate>().IsTurningOnOff();

        }

    }
    
}
