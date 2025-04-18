using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text pointsText;
    Image backgroundImage;

    void Start()
    {
        gameObject.SetActive(false); 
        backgroundImage = GetComponent<Image>();
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        backgroundImage.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 0.78f, 0.86f); // Alpha range between 200 and 220 out of 255
        pointsText.text = score.ToString() + " POINTS";
    }
    public void RestartButton()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton()
    {
        Time.timeScale = 1; //Unpause the game
        SceneManager.LoadScene("MenuScene");
    }
}
