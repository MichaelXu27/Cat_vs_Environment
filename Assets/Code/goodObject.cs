using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    Vector2 originalPosition;
    Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Cat"))
        {
            rb.isKinematic = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //reload the scene if the cat comes in contact with the bad obstacle
        if (other.gameObject.GetComponent<Movement>()) //movement can be replaced
        {
            //add some scoring system here
            ResetObject();
        }


        //this will destroy the object that has the script that touches the ground
        if (other.gameObject.name.Equals("Ground"))
        {
            //destroys the object after 3 seconds of touching the ground
            //Destroy(gameObject, 3f);
            ResetObject();
        }
    }

    void ResetObject()
    {
        rb.isKinematic = true;

        transform.position = originalPosition;
        transform.rotation = originalRotation;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
