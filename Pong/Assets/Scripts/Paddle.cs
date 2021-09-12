using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    PLAYER_1,
    PLAYER_2
}

public class Paddle : MonoBehaviour
{
    

    public PlayerType player;
    public float limit = 3.7f;
    public float speed = 1f;

    private float _inputY = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        Vector3 dir = Vector3.up * _inputY * speed * Time.deltaTime;
        if ((transform.position + dir).y < limit && (transform.position + dir).y > -limit)
        {
            transform.position = transform.position + dir;
        }
    }

    private void ReadInput()
    {
        if (player == PlayerType.PLAYER_1)
        {
            if (Input.GetKey(KeyCode.W))
                _inputY = 1.0f;
            else if (Input.GetKey(KeyCode.S))
                _inputY = -1.0f;
            else
                _inputY = 0.0f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                _inputY = 1.0f;
            else if (Input.GetKey(KeyCode.DownArrow))
                _inputY = -1.0f;
            else
                _inputY = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.transform.GetComponent<Ball>();
        if (ball != null)
        {
            ball.AlterDirection(collision.transform.position - transform.position);
            ball.IncrementVelocity();
        }


    }

}
