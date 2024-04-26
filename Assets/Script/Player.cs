using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    private Rigidbody2D rb2D;
    private bool isGrounded;
    private float speed;
    private float jumpForce;

    private Vector2 move;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = 40f;
        jumpForce = 10f;
    }

    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (move.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        MovePlayerFree(move);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            isGrounded = false;
        }

    }

    private void FixedUpdate()
    {
        rb2D.AddForce(move * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void MovePlayerFree(Vector2 moveVector)
    {
        rb2D.MovePosition(rb2D.position + moveVector * speed * Time.fixedDeltaTime);
    }
}
