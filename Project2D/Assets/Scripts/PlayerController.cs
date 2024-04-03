using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    public bool ground;
    public Transform groundDetection;
    public LayerMask groundMask;

    public int doubleJump = 1;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ground = Physics2D.OverlapCircle(groundDetection.position, 0.2f, groundMask);

        if (Input.GetButtonDown("Jump") && ground == true)
        {
            rb.velocity = Vector2.up * 12;
        }

        if (Input.GetButtonDown("Jump") && ground == false && doubleJump > 0)
        {
            rb.velocity = Vector2.up * 12;
            doubleJump--;

        }
        if (ground)
        {
            doubleJump = 1;
        }

        direction = Input.GetAxis("Horizontal");

        if(direction > 0)
        {
            transform.localScale = facingRight;
        }
        if(direction < 0)   
        {
            transform.localScale = facingLeft;
        }
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

    }
}
