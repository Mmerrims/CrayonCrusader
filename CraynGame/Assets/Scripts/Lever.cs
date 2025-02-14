using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
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
        if (door1.activeInHierarchy != true)
        {
            door1.SetActive(false);
            door2.SetActive(true);
        }
        else if (door2.activeInHierarchy != true)
        {
            door1.SetActive(true);
            door2.SetActive(false);
        }
    }
}
