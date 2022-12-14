using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float movementVelocity = 5;
    [SerializeField] float jumpVelocity = 5;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _rigidbody.velocity = new Vector3(horizontalInput * movementVelocity, _rigidbody.velocity.y,
            verticalInput * movementVelocity);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        // if (Input.GetKeyDown("space"))
        // {
        //     _rigidbody.velocity = new Vector3(0, 5, 0);
        // }

        // if (Input.GetKey("up") || Input.GetKey("w"))
        // {
        //     _rigidbody.velocity = new Vector3(0, 0, 5);
        // }
        // if (Input.GetKey("right")|| Input.GetKey("d"))
        // {
        //     _rigidbody.velocity = new Vector3(5, 0, 0);
        // }
        // if (Input.GetKey("left") || Input.GetKey("a") )
        // {
        //     _rigidbody.velocity = new Vector3(-5, 0, 0);
        // }
        // if (Input.GetKey("down") || Input.GetKey("s") )
        // {
        //     _rigidbody.velocity = new Vector3(0, 0, -5);
        // }

    }

    void Jump()
    {
        var velocity = _rigidbody.velocity;
        velocity = new Vector3(velocity.x, jumpVelocity, velocity.z);
        _rigidbody.velocity = velocity;

        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
