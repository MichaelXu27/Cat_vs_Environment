using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{ 
    private Rigidbody2D player;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool isDashing = false;
    public float dashDuration = 0.2f;
    private float nextDashTime = 0f;
    private float dashEndTime;
    public float acceleration = 75;
    
    // Use this for initialization
    void Start () 
    {
        player = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update() 
    { 
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); 
        // Up arrow to jump
        if (isTouchingGround && Input.GetKeyDown(KeyCode.UpArrow)) {
            player.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
        }
        // move left & right
        if (!isDashing)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                player.AddForce(Vector2.left * acceleration * Time.deltaTime, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.AddForce(Vector2.right * acceleration * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
        // dash when space bar and left/right arrow are pressed
        if (Time.time >= nextDashTime && isTouchingGround && Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                StartDash(Vector2.left);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                StartDash(Vector2.right);
            }
        }
        // stop dash after duration
        if (isDashing && Time.time >= dashEndTime)
        {
            isDashing = false;
            player.velocity = Vector2.zero;
        }
    }
    void StartDash(Vector2 direction)
    {
        isDashing = true;
        dashEndTime = Time.time + dashDuration;
        nextDashTime = Time.time + 1f;
        player.velocity = direction * 30f;
    }
}

