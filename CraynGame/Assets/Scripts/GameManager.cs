//Written by Quinn
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string gameState;
    [SerializeField] private GameObject BlueController;
    [SerializeField] private GameObject YellowController;
    private bool playersCanMove;
    private string winningTeam;
    [SerializeField] private GameObject BlueWinscreen;
    [SerializeField] private GameObject YellowWinScreen;

    [SerializeField] private GameObject EndScreen;




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

                EndScreen.SetActive(true);

                if (winningTeam == "Blue")
                {
                    BlueWinscreen.SetActive(true);
                }
                else if (winningTeam == "Yellow")
                {
                    YellowWinScreen.SetActive(true);
                }

                break;

            default: 
                break;
        }
    }

    public void SetStateEnded(string teamThatWon)
    {
        gameState = "Ended";
        winningTeam = teamThatWon;
        Debug.Log(winningTeam + " has won!!");
        Statemanager();
    }


}
