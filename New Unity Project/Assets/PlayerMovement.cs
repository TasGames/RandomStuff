using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    protected Rigidbody playerRigidbody;

    protected Vector3 moveInput;
    protected Vector3 moveVelocity;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate()
    {
        playerRigidbody.velocity = moveVelocity;
    }
}
