using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Movement speed as a float
    public float _speed = 5f;

    // Store the current movement direction
    private Rigidbody _rb;
    private const float Force = 15000f;
    private float _levelOne = 195f;
    private float _levelTwo = 800f;
    private float _levelThree = 1600f;
    private float _winPos = 2000f;
    private float _tooHigh = 10f;

    // to Check if the cat is on the ground, if otherwise disable jumping
    private bool _isGrounded; 
    // if player hits a barrier, cat ded
    private bool _gameOver;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        while (!_gameOver)
        {
            if (_isGrounded && transform.position.y <= _tooHigh)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
                {
                    _rb.AddForce(Vector3.up * Force * Time.deltaTime);
                }
            }

            // Handle speed changes based on position
            if (transform.position.x >= _levelOne)
            {
                _speed = 10f;
            }

            if (transform.position.x >= _levelTwo)
            {
                _speed = 15f;
            }

            if (transform.position.x >= _levelThree)
            {
                _speed = 20f;
            }

            if (transform.position.x >= _winPos)
            {
                _speed = 0;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            // Move the player forward
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        }
    }

    void onCollisionEnter(Collision other)
    {

    }

    // Detect collision with the ground (for grounded check)
    void OnCollisionEnter(Collision other)
    {
        // If we collide with an object tagged "Ground", we mark the cat as grounded
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        if (other.gameObject.CompareTag("Barrier"))
        {
            _gameOver = true;
            //destroy the player then display game over
            Destroy(other.gameObject);
        }
    }

    // Detect when the cat stops colliding with the ground (for grounded check)
    void OnCollisionExit(Collision other)
    {
        // If we exit the ground collision, mark the cat as not grounded
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
