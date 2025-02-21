using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen; 
    public int score;

    public void GameOver()
    {
        gameOverScreen.Setup(score); 
    }
}
