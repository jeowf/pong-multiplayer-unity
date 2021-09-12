using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.transform.GetComponent<Ball>();
        if (ball != null)
        {
            ball.MirrorDirection();
        }
    }
}
