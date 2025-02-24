using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen; 

    public static GameController instace;

    private void Awake()
    {
        if (!instace)
            instace = this;
    }

    public void GameOver()
    {
        gameOverScreen.Setup(ScoreManager.instance.score);
        Time.timeScale = 0; 
    }
}
