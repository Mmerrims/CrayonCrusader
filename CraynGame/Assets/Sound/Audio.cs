using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject runningAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isMoving == true)
        {
            runningAudio.SetActive(true);
        }
        else
        {
            runningAudio.SetActive(false);
        }
    }
}
