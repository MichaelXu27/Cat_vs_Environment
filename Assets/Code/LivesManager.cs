using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    public int life = 3;
    public Text livesText;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        livesText.text = life.ToString();
    }

    public void AddLife()
    {
        life += 1;
        livesText.text = life.ToString();
    }

    public void LoseALife()
    {
        life -= 1;
        livesText.text = life.ToString();
    }
}
