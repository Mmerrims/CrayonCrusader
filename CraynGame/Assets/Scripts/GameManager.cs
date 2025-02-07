using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string GameState;



    private void Statemanager()
    {
        switch (GameState)
        {
            case "NotStarted":
                break;

            case "Running":
                break;

            case "Ended":
                break;

            default: 
                break;
        }
    }

}
