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
    public float speed = 5f;

    // Use this for initialization
    void Start () 
    {
        player = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update() 
    { 
        // jump
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isTouchingGround && Input.GetButtonDown("Jump")) {
            //player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            //modified jump with force impulse
            player.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);

        }
        // move left & right
        if (Input.GetKey(KeyCode.LeftArrow)) {
            player.AddForce(Vector2.left * 25f * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(Vector2.right * 25f * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
