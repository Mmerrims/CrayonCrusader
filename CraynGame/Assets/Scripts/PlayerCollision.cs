using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject victoryTrigger;
    [SerializeField] private string team;
    [SerializeField] private AudioClip winFanfare;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(victoryTrigger.tag) != false)
        {
            Debug.Log(team + "has won the race!");
            AudioSource.PlayClipAtPoint(winFanfare, victoryTrigger.transform.position);
            gameManager.SetStateEnded(team);
        }
    }

    public void PlayerControllerHit()
    {
        playerController.GetIsHit();
    }
}
