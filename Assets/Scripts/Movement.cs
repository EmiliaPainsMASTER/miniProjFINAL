using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Movement speed as a float
    private float _speed = 5f;

    // Store the current movement direction
    private Rigidbody _rb;
    private const float Force = 15000f;
    private const float LevelOne = 195f;
    private const float LevelTwo = 800f;
    private const float LevelThree = 1600f;
    private const float WinPos = 2000f;
    private const float TooHigh = 10f;

    // to Check if the cat is on the ground, if otherwise disable jumping
    private bool _isGrounded;
    // if player hits a barrier, cat ded
    private bool _gameOver = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_gameOver)
        {
            if (_isGrounded && transform.position.y <= TooHigh)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
                {
                    _rb.AddForce(Vector3.up * (Force * Time.deltaTime));
                }
            }

            // Handle speed changes based on position
            if (transform.position.x >= LevelOne)
            {
                _speed = 10f;
            }

            if (transform.position.x >= LevelTwo)
            {
                _speed = 15f;
            }

            if (transform.position.x >= LevelThree)
            {
                _speed = 20f;
            }

            if (transform.position.x >= WinPos)
            {
                _speed = 0;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            // Move the player forward
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        }
    }

    // Detect collision with the ground (for grounded check)
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        if (other.gameObject.CompareTag("Barrier"))
        {
            _gameOver = true;
            Destroy(gameObject); // Destroy the player
        }
    }

    // Detect when the cat stops colliding with the ground (for grounded check)
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
