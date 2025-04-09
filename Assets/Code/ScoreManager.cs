using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public Text scoreText;
    public Text highScoreText;

    public LevelUp levelUp;

    public int score = 0;
    private int highscore = 0;

    public int[] levelUpThresholds = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 999 };

    int currentLevel = 0;


    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highscore.ToString();

    }


    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        CheckForLevelUp();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    void CheckForLevelUp()
    {
        if (score >= levelUpThresholds[currentLevel])
        {
            currentLevel += 1;
            levelUp.Play(currentLevel);
            //IncreaseDifficulty(levelNumber);         
        }
    }

    public void IncreaseDifficulty(int levelNumber)
    {
        return;
    }
}
