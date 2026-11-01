using UnityEngine;
using UnityEngine.InputSystem;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float Movex;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Movex, 0);
        if (input.sqrMagnitude < 0.01f) return;
        Vector3 moveDirection = transform.forward * 0 + transform.right * input.x;
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

    private void onMove(InputValue movement)
    {
        Vector2 input = movement.Get<Vector2>();

        Movex = input.x;
    }

    private void onJump(InputValue jump)
    {}
}
