//Written by Quinn
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string gameState;
    [SerializeField] private GameObject BlueController;
    [SerializeField] private GameObject YellowController;
    private bool playersCanMove;
    [SerializeField] private GameObject WinScreen;



    private void Statemanager()
    {
        switch (gameState)
        {
            case "NotStarted":
                Debug.Log("Game is not started");
                break;

            case "Running":
                Debug.Log("Game has started running");
                playersCanMove = true;

                BlueController.SetActive(true);
                YellowController.SetActive(true);
                break;

            case "Ended":
                Debug.Log("Game has Ended");
                
                playersCanMove = false;
                BlueController.SetActive(false);
                YellowController.SetActive(false);

                break;

            default: 
                break;
        }
    }

    public void SetStateEnded()
    {
        gameState = "Ended";
        Statemanager();
    }

}
