using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject victoryTrigger;
    [SerializeField] private string team;
    [SerializeField] private AudioClip winFanfare;
    public bool canGetHit;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        canGetHit = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(victoryTrigger.tag) != false)
        {
            //Debug.Log(team + "has won the race!");
            AudioSource.PlayClipAtPoint(winFanfare, victoryTrigger.transform.position);

            gameManager.SetStateEnded(team);
        }
    }

    public void PlayerControllerHit()
    {
        playerController.GetIsHit();
    }


}
