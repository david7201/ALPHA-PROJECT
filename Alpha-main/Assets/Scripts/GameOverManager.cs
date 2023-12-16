using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use this for UI Text
// using TMPro; // Uncomment if using TextMeshPro

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText; // Assign in inspector

    public void ShowGameOver()
    {
        gameOverText.SetActive(true); // Show the game over text
        Time.timeScale = 0f; // Freeze the game
    }
}
