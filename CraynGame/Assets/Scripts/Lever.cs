using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;

    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private Sprite Door1Open;
    [SerializeField] private Sprite Door1Closed;
    [SerializeField] private Sprite Door2Open;
    [SerializeField] private Sprite Door2Closed;

    //IMPORTANT. This goes on each lever. There should be two levers and three doors linked up. Door 2 should be same
    //in both. Door 1 should be different in both. 

    public void GetOpenClose()
    {
        OpenClose();
    }

    private void OpenClose()
    {
        //Door1 checker
        if (Door1.GetComponent<Door>().isOpen == false)
        {
            //Door1 is closed. This opens doorA
            //Door1 Sprite is changed to the inactive sprite.
            //Door1 collision is disabled.
            Debug.Log("Gate A is now open");
            Door1.GetComponent<Door>().isOpen = true;
            Door1.GetComponent<BoxCollider2D>().enabled = false;
            Door1.GetComponent<SpriteRenderer>().sprite = Door1Open;
        }
        else if (Door1.GetComponent<Door>().isOpen == true)
        {
            //Door1 is open. This closes doorA
            Debug.Log("Gate A is now closed");
            Door1.GetComponent<Door>().isOpen = false;
            Door1.GetComponent<BoxCollider2D>().enabled = true;
            Door1.GetComponent<SpriteRenderer>().sprite = Door1Closed;
        }

        //Door2 checker
        if (Door2.GetComponent<Door>().isOpen == false)
        {
            //Door2 is closed. This opens doorA
            Debug.Log("Gate B is now open");
            Door2.GetComponent<Door>().isOpen = true;
            Door2.GetComponent<BoxCollider2D>().enabled = false;
            Door2.GetComponent<SpriteRenderer>().sprite = Door2Open;
        }
        else if (Door1.GetComponent<Door>().isOpen == true)
        {
            //Door2 is open. This closes doorA
            Debug.Log("Gate A is now closed");
            Door2.GetComponent<Door>().isOpen = false;
            Door2.GetComponent<BoxCollider2D>().enabled = true;
            Door2.GetComponent<SpriteRenderer>().sprite = Door2Closed;




            /*Debug.Log("OpenClose");
            if (door1.activeInHierarchy != true)
            {
                Debug.Log("Door opened");
                door1.SetActive(true);
                door2.SetActive(false);
                AudioSource.PlayClipAtPoint(doorOpen, door1.transform.position);
            }
            else if (door2.activeInHierarchy != true)
            {
                Debug.Log("Door CLosed");
                door1.SetActive(false);
                door2.SetActive(true);
                AudioSource.PlayClipAtPoint(doorOpen, door2.transform.position);
            }
            else
            {
                Debug.Log("SOmething whent wrong");
            }*/
        }
    }
}
