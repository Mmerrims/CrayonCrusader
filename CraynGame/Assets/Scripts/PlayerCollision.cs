using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject victoryTrigger;
    [SerializeField] private string team;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(victoryTrigger.tag) != false)
        {
            Debug.Log(team + "has won the race!");
            gameManager.SetStateEnded(team);
        }
    }
}
