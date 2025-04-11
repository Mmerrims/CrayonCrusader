//Written by Quinn
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameObject TieScreen;

    [SerializeField] private GameObject EndScreen;
    [SerializeField] private Timer Timer1;
    [SerializeField] private Timer Timer2;
    [SerializeField] private float RestartGameTimer;

    public int CountDownTime;
    [SerializeField] private TMP_Text BlueCountdownTimerText;
    [SerializeField] private TMP_Text YellowCountdownTimerText;


    private void Statemanager()
    {
        switch (gameState)
        {
            case "NotStarted":
                Debug.Log("Game is not started");
                playersCanMove = false;
                BlueController.SetActive(false);
                YellowController.SetActive(false);
                //Start the 3 second countdown
                StartCoroutine(Startcountdown());
                
                break;

            case "Running":
                Debug.Log("Game has started running");
                
                //Starts the ingame timer
                Timer1.gameObject.SetActive(true);
                Timer2.gameObject.SetActive(true);
                Timer1._timerActive = true;
                Timer2._timerActive = true;
                

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
                    TieScreen.SetActive(true);

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
        while( CountDownTime > 0)
        {
            BlueCountdownTimerText.text = CountDownTime.ToString();
            YellowCountdownTimerText.text = CountDownTime.ToString();

            yield return new WaitForSeconds(1f);

            CountDownTime--;


        }


        BlueCountdownTimerText.text = ("GO!");
        YellowCountdownTimerText.text = ("GO!");

        yield return new WaitForSeconds(1f);

        YellowCountdownTimerText.gameObject.SetActive(false);
        BlueCountdownTimerText.gameObject.SetActive(false);
        gameState = ("Running");
        Statemanager();
        //Debug.Log(secondsRemaining);
    }

    private void Start()
    {
        Cursor.visible = false;
    }
}
