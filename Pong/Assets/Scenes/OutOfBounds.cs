using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public PlayerType player;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.transform.GetComponent<Ball>();
        if (ball != null)
        {
            gameManager.MakeScore(player);
        }
    }
}
