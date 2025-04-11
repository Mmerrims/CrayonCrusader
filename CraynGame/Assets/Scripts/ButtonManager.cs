using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    private bool isReadyRight = false;
    private bool isReadyLeft = false;
    [SerializeField] private float TimeToStart;
    [SerializeField] private GameObject RightButton;
    [SerializeField] private GameObject LeftButton;
    [SerializeField] private Sprite ReadySprite;
    
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
        SceneManager.LoadScene("QuinnLevelDesignTest2");
    }
    //These need to be fixed. I'm not completely sure why it's throwing runtime errors. 
    public void ChangeButtonTextRight()
    {
        RightButton.GetComponent<Image>().sprite = (ReadySprite);
    }

    public void ChangeButtonTextLeft()
    {
        LeftButton.GetComponent<Image>().sprite = (ReadySprite);
    }

    private void Start()
    {
        Cursor.visible = false;
    }
}
