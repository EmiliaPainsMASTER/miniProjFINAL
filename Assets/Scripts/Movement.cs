using UnityEngine;

public class Movement : MonoBehaviour
{
    //player speed
    private float _speed = 5f;
    private Rigidbody _rb;
    //ability to jump
    private const float JumpForce = 1000f;
    //level positions
    private float _levelOne = 195f;
    private float _levelTwo = 800f;
    private float _levelThree = 1600f;
    private float _winPos = 2000f;

    //initially false by default
    private bool _isGrounded;
    private bool _gameOver;

    //on game state
    void Start()
    {
        //grab the rigid body
        _rb = GetComponent<Rigidbody>();
    }

    //per frame
    void Update()
    {
        //check if game is over
        if (_gameOver)
            return;

        //Check if player is on ground, and is holding Space or W
        if (_isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            //applies the addForce method to the player of Vector3up times the JumpForce which is 1000f
            _rb.AddForce(Vector3.up * JumpForce);
        }

        //change speed on getting past level
        if (transform.position.x >= _levelOne)
        {
            _speed = 7.5f;
        }
        if (transform.position.x >= _levelTwo)
        {
            _speed = 10f;
        }
        if (transform.position.x >= _levelThree)
        {
            _speed = 12.5f;
        }
        if (transform.position.x >= _winPos)
        {
            _speed = 0;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _gameOver = true;
        }

        // move left to right
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }


    void OnCollisionEnter(Collision other)
    {
        // check if player is on ground
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
            _gameOver = true;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}