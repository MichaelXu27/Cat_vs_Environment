using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{ 
    public float jumpSpeed = 9f;
    private Rigidbody2D player;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    // Use this for initialization
    void Start () 
    {
        player = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update() 
    { 
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isTouchingGround && Input.GetButtonDown("Jump")) {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed); 
        }
    }
}
