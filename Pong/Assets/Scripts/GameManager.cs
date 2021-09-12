using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float offset = 0.5f;
    public Ball ball;
    public Paddle player1;
    public Paddle player2;

    public Text score1;
    public Text score2;

    private int _score1 = 0;
    private int _score2 = 0;

    private PlayerType _currentPlayer;
    private bool _releasing;

    IEnumerator gambs;

    void Start()
    {
        _releasing = true;
        _currentPlayer = PlayerType.PLAYER_1;

    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && player2 != null)
        {
            if (_releasing)
            {
                if (_currentPlayer == PlayerType.PLAYER_1)
                {
                    ball.transform.position = player1.transform.position + Vector3.right * offset;
                }
                else
                {
                    ball.transform.position = player2.transform.position - Vector3.right * offset;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (_currentPlayer == PlayerType.PLAYER_1)
                    {
                        ball.InitVelocity(true);
                    }
                    else
                    {
                        ball.InitVelocity(false);
                    }
                    _releasing = false;
                }
            }
        }
    }

    public void MakeScore(PlayerType player)
    {
        if (player == PlayerType.PLAYER_1)
        {
            _score1++;
        } else
        {
            _score2++;
        }
        score1.text = _score1.ToString();
        score2.text = _score2.ToString();
        _currentPlayer = player;
        _releasing = true;

        if (ball == null)
            ball = GameObject.Find("ball_obj(Clone)").GetComponent<Ball>();
        //ball = GameObject.FindObjectOfType<Ball>();
        if (gambs != null)
            StopCoroutine(gambs);
        gambs = Gambs(ball);
        
        StartCoroutine(gambs);

    }

    IEnumerator Gambs(Ball ball)
    {
        yield return new WaitForSeconds(1);
        ball.ResetProperties(_currentPlayer == PlayerType.PLAYER_1);
    }
}
