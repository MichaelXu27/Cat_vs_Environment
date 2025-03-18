using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerUp : MonoBehaviour
{
    public static int lifeRemaining = 3;

    void OnCollisionEnter2D(Collision2D heart)
    {
        if (heart.gameObject.name.Equals("Cat"))
        {
            Destroy(gameObject);
            LivesManager.instance.AddLife();
            lifeRemaining += 1;
            Debug.Log("Lives Remaining " + lifeRemaining);
        }
    }
}
