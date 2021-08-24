using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public float increment = 2f;


    private Vector3 _direction = Vector3.right;
    private float _speed;
    void Start()
    {
        _speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void MirrorDirection()
    {
        //_direction = -_direction;
        _direction.y = -_direction.y;

    }

    public void AlterDirection(Vector3 newDirection)
    {
        _direction = newDirection.normalized;
    }

    public void IncrementVelocity()
    {
        _speed += increment;
    }

    public void ResetProperties()
    {
        _speed = speed;
        //_direction = Vector3.right;
        //transform.position = Vector3.zero;
    }

    public void InitVelocity(bool right)
    {
        if (right)
        {
            _direction = Vector3.right;
        } else
        {
            _direction = Vector3.left;
        }
    }


}
