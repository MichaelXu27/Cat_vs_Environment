using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    //outlets
    Rigidbody2D _rb;

    //state tracking
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float acceleration = 0.25f;
        float maxSpeed = 1f;

        //home in on target
        ChooseNearestTarget();
        if (target != null)
        {
            //rotate towards the target
            Vector2 directionToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            _rb.MoveRotation(angle);
        }

        //adding force
        _rb.AddForce(transform.right * acceleration);

        //cap max speed
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);


    }

    void ChooseNearestTarget()
    {
        Movement player = FindObjectOfType<Movement>();
        if(player != null)
        {
            target = player.transform;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Movement>())
        {
            
            Destroy(gameObject);

            //GameObject explosion = Instantiate(
            //    GameController.instance.explosionPrefab,
            //    transform.position,
            //    Quaternion.identity
            //);
            //Destroy(explosion, 0.25f);

            //GameController.instance.EarnPoints(10);

        }
    }
}

