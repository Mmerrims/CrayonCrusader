using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour
{
    PlayerInput debugthing;
    InputAction restart;
    InputAction quit;
    // Start is called before the first frame update
    private void Start()
    {
     debugthing = GetComponent<PlayerInput>();
        restart = debugthing.currentActionMap.FindAction("Restart");
        quit = debugthing.currentActionMap.FindAction("Quit");
        //restart.started += Restart_Started;
        //quit.started += Quit_Started;
    }

    public void Quit_Started(InputAction.CallbackContext context)
    {
        if (context.performed != false)
        {
            Application.Quit();
            print("We're Closed.");
        }


    }
    public void Restart_Started(InputAction.CallbackContext context)
    {
        if (context.performed != false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
         
    }
  

}
