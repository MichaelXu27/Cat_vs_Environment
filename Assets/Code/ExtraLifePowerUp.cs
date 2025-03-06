using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerUp : MonoBehaviour
{
    public static int lifeRemaining = 1;

    void OnCollisionEnter2D(Collision2D heart)
    {
        if (heart.gameObject.name.Equals("Cat"))
        {
            Destroy(gameObject);
            lifeRemaining += 1;
            Debug.Log("Lives Remaining " + lifeRemaining);
        }
    }
}
