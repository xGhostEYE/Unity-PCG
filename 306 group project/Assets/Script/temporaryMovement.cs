using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temporaryMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float Speed = 100, jumpForce = 300;
    [SerializeField] bool isGround = false;
    [SerializeField] int jumpCount = 0;
    [SerializeField] bool canDoubleJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 movement = rb.velocity;
        movement.x = Speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        rb.velocity = movement;
        if (isGround)
        {
            canDoubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                rb.AddForce(new Vector2(0, jumpForce));
                isGround = false;
                jumpCount = 1;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    rb.AddForce(new Vector2(0, jumpForce));
                    jumpCount = 2;
                    canDoubleJump = false;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        jumpCount = 0;
    }
}
