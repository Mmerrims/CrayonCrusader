using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;




public class ButtonManager : MonoBehaviour
{
    public bool isReadyRight = false;
    public bool isReadyLeft = false;
    //[SerializeField] private GameObject LeftButton;
    //[SerializeField] private GameObject RightButton;

    // Start is called before the first frame update

    
    public void ReadyUpRight()
    {
        if (isReadyRight == false)
        {
            Debug.Log("right button is ready");
            isReadyRight = true;
        }
        else if (isReadyRight == true)
        {
            Debug.Log("right button is not ready");
            isReadyRight = false;

        }

         if (isReadyRight == true && isReadyLeft == true)
        {
            Debug.Log("right and left are ready");
            //Start game here
            StartGame();
        }

    }


    public void ReadyUpleft()
    {
        if (isReadyLeft == false)
        {
            isReadyLeft = true;
        }
        else if (isReadyLeft == true)
        {
            isReadyLeft = false;
        }

         if (isReadyRight == true && isReadyLeft == true)
        {
            //Start game here
            StartGame();

        }
    }

    private void StartGame()
    {
        Debug.Log("This should load a scene");
        SceneManager.LoadScene("GameplayScene");
    }
}
