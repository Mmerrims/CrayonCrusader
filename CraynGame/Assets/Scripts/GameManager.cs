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
    [SerializeField] private GameObject YellowLoseScreen;
    [SerializeField] private GameObject BlueLoseScreen;

    [SerializeField] private GameObject EndScreen;
    [SerializeField] private Timer Timer1;
    [SerializeField] private Timer Timer2;
    [SerializeField] private float RestartGameTimer;

    private void Statemanager()
    {
        switch (gameState)
        {
            case "NotStarted":
                Debug.Log("Game is not started");
                //Start the 3 second countdown
                StartCoroutine(Startcountdown());
                
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
                Timer1.StopTimer();
                Timer2.StopTimer();

                StartCoroutine(GoToMainMenu());

                if (winningTeam == "Blue")
                {
                    BlueWinscreen.SetActive(true);
                }
                else if (winningTeam == "Yellow")
                {
                    YellowWinScreen.SetActive(true);
                }

                else if (winningTeam == "Tie")
                {
                    Debug.Log("Neither team won");
                    YellowLoseScreen.SetActive(true);
                    BlueLoseScreen.SetActive(true);
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

    private IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(RestartGameTimer);
        SceneManager.LoadScene("TitleScene2");
        yield return null;
    }

    private void Awake()
    {
        gameState = ("NotStarted");
        Statemanager();
    }

    private IEnumerator Startcountdown()
    {
        //This is a 5 second countdown
        float secondsRemaining = 2f;
        
        while(secondsRemaining >= 0)
        {
            yield return new WaitForSeconds(secondsRemaining);
            secondsRemaining--;
            
        }
        //Start the Game
        gameState = ("Running");
        Statemanager ();
        //Debug.Log(secondsRemaining);
    }


}
