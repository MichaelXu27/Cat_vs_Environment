using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUp : MonoBehaviour
{
    public static bool isInvincible;

    void OnCollisionEnter2D(Collision2D star)
    {
        if (star.gameObject.name.Equals("Cat"))
        {
            Movement playerScript = star.gameObject.GetComponent<Movement>();
            playerScript.StartCoroutine(playerScript.ResetInvincibility());
            Destroy(gameObject);
            isInvincible = true;
            Debug.Log("Status " + isInvincible);
        }
    }
}