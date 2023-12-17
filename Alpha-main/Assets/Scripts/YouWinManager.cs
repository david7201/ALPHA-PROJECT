using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene"); 
    }

    public void ShowYouWinScreen(bool show)
    {
        gameObject.SetActive(show);
    }
}

