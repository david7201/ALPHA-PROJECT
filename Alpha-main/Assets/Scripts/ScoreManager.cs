using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;    
    private int score = 0;
    public GameObject gameOverPanel;

    

    void Awake()
    {
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
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
    }
}
