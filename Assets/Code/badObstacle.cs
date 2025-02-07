using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badObstacle : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
