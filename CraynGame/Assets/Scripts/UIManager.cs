using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene"); 
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
