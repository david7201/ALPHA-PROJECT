using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager  : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene"); 
    }

    public void ShowGameOverScreen(bool show)
    {
        gameObject.SetActive(show);
    }
}
