using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    float x;
    float z;
    Vector3 move;
    //gravedad
    Vector3 velocity;
    public float gravity = -15f;

    public Transform groundCheck;
    float radius = 0.4f;
    public LayerMask mask;
    bool isGrounded = false;
    public float jumpForce = 1f;

    private float jumpValue;
    private void Start()
    {
        jumpValue = Mathf.Sqrt(jumpForce * -2 * gravity);
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = gravity;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpValue;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
