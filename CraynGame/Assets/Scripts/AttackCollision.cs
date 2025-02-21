using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    private GameObject hitObject;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Lever") != false)
        {
            Debug.Log("Lever has been hit");
            hitObject = collision.gameObject;

            hitObject.GetComponent<Lever>().GetOpenClose();
        }
        else if (collision.CompareTag("Player"))
        {
            hitObject = collision.gameObject;
            hitObject.GetComponent<PlayerCollision>().PlayerControllerHit();
        }

    }
}
