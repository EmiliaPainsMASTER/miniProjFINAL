using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Movement speed as a float
    private float _speed = 5.0f;
    
    // Store the current movement direction
    private Rigidbody _rb;
    private float force = 2500;

    // Update is called once per frame
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //TODO add a isGrounded function to prevent the cat from flying into the air
        // Update moveDirection based on input
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(Vector3.up * force * Time.deltaTime);
        }
        //if player position is at - 50 increase speed
        if(transform.position.x >= 55)
        {
            _speed = 7.5f;
        }
        //ToDo check background (denotes where a level ends) positions using barriers 
        // if(transform.position.x >= 55)
        // {
        //     _speed = 7.5f;
        // }
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}