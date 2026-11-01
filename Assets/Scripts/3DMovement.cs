using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Data;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float Movex;
    private float Movey;
    private float Lookx;
    private float Looky;
    private float Jumpx;
    private bool isGrounded;
    private float rotate;
    public float speed;
    private Rigidbody rb;
    public float jumpForce = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
   
        rotate += Lookx;
        transform.rotation = Quaternion.Euler(0, rotate, 0);

        Vector2 input = new Vector2(Movex, Movey);
        if (input.sqrMagnitude < 0.01f) return;

        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        rotate += Lookx;
        transform.rotation = Quaternion.Euler(0, rotate, 0).normalized;
    }

    private void OnMove(InputValue movement)
    {
        Vector2 movementVector = movement.Get<Vector2>();

        Movex = movementVector.x;
        Movey = movementVector.y;
    }

      private void OnLook(InputValue look)
    {
        Vector2 lookVector = look.Get<Vector2>();
        Lookx = lookVector.x * 3;
        Looky = lookVector.y * 3;
    }

    private void OnJump(InputValue jump)
    {
        if (jump.isPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Simple ground detection using collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
