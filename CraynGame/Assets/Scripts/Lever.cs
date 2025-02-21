using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private AudioClip doorOpen;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    public void GetOpenClose()
    {
        OpenClose();
    }

    private void OpenClose()
    {
        Debug.Log("OpenClose");
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
        }
    }
}
