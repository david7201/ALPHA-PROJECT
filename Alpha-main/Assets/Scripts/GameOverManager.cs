using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText; 

    

    public void ShowGameOver()
    {
        gameOverText.SetActive(true); 
        
    }
}
