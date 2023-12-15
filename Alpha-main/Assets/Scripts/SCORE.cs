using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int score = 0;

    void Awake()
    {
        // Singleton pattern to ensure only one ScoreManager exists
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void SubtractScore(int value)
    {
        score -= value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        // Implement game over logic here
        Debug.Log("Game Over!");
        // For example, disable player controls, show a game over screen, etc.
    }
}

