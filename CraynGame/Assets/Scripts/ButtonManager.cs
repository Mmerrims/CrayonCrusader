using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ButtonManager : MonoBehaviour
{
    private bool isReadyRight = false;
    private bool isReadyLeft = false;
    [SerializeField] private float TimeToStart;
    [SerializeField] private GameObject RightText;
    [SerializeField] private GameObject LeftText;
    [SerializeField] private string IsReadyText;
    
    public void ReadyUpRight()
    {
        if (isReadyRight == false)
        {
            Debug.Log("right button is ready");
            isReadyRight = true;
        }


         if (isReadyRight == true && isReadyLeft == true)
        {
            Debug.Log("right and left are ready");
            //Start game here
            GameStartTimer();
        }

    }


    public void ReadyUpleft()
    {
        if (isReadyLeft == false)
        {
            isReadyLeft = true;
        }


         if (isReadyRight == true && isReadyLeft == true)
        {
            //Start game here
            GameStartTimer();
        }
    }

    private void GameStartTimer()
    {
        //Edit the text for a 3-2-1 countdown. 

        //3 second countdown for starting the game
        StartCoroutine(Countdown());

    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(TimeToStart);
        SceneManager.LoadScene("GameplayScene");
    }

    public void ChangeButtonTextRight()
    {
        RightText.GetComponent<TMP_Text>().text = (IsReadyText);
    }

    public void ChangeButtonTextLeft()
    {
        LeftText.GetComponent<TMP_Text>().text = (IsReadyText);
    }


}
