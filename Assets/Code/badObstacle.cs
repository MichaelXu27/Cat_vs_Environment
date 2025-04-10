using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badObstacle : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 originalPosition;
    Quaternion originalRotation;

    private GameController gameController;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalPosition = transform.position;
        originalRotation = transform.rotation;

        rb.isKinematic = false;

        gameController = FindObjectOfType<GameController>();
        AddRedObjectBorder();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Cat"))
        {
            rb.isKinematic = false; //can delete later
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Movement>() && gameObject.GetComponent<badObstacle>())
        {
            if (StarPowerUp.isInvincible == false)
            {
                LivesManager.instance.LoseALife();
                ExtraLifePowerUp.lifeRemaining -= 1;
                Debug.Log("life " + ExtraLifePowerUp.lifeRemaining);
                Destroy(gameObject, 0.2f);
                if (ExtraLifePowerUp.lifeRemaining < 1)
                {
                    gameController.GameOver();
                    Destroy(other.transform.gameObject);
                    ExtraLifePowerUp.lifeRemaining = 3;
                }
            }
        }

        //this will destroy the object that has the script that touches the ground
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground") && !gameObject.CompareTag("SideToSideObject")) 
        {
            //destroys the object after 0.5 seconds of touching the ground
            Destroy(gameObject, 0.5f);
        }
        if (other.gameObject.CompareTag("goodObject") && !gameObject.CompareTag("SideToSideObject"))
        {
            Destroy(gameObject);
        }
    }

    void AddRedObjectBorder()
    {
        SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();
        if(currentSprite == null) { return; }

        GameObject borderObj = new GameObject("RedBorder");
        borderObj.transform.SetParent(transform);
        borderObj.transform.localPosition = Vector3.zero;
        borderObj.transform.localScale = Vector3.one * 1.1f;
        
        
        SpriteRenderer borderSR = borderObj.AddComponent<SpriteRenderer>();
        borderSR.sprite = currentSprite.sprite;
        borderSR.color = Color.red;
        borderSR.sortingLayerID = currentSprite.sortingLayerID;
        borderSR.sortingOrder = currentSprite.sortingOrder - 1;

    }
}
