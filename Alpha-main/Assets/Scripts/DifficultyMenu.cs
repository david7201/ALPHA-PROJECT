using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    // Link the buttons from the Unity Editor
    public Button EasyButton;
    public Button MediumButton;
    public Button HardButton;

    public static DifficultyManager instance;

    


    void Start()
    {
        // Add listeners to the buttons
        EasyButton.onClick.AddListener(OnEasyButtonClick);
        MediumButton.onClick.AddListener(OnMediumButtonClick);
        HardButton.onClick.AddListener(OnHardButtonClick);
    }

    void OnEasyButtonClick()
    {
        Debug.Log("Easy difficulty selected!");

        SceneManager.LoadScene("EasyGame"); // Load "MyGame" scene or perform actions related to Easy difficulty
    }

    void OnMediumButtonClick()
    {
        Debug.Log("Medium difficulty selected!");

        SceneManager.LoadScene("MediumGame"); // Load "MyGame" scene or perform actions related to Medium difficulty
    }

    void OnHardButtonClick()
    {
        Debug.Log("Hard difficulty selected!");

        SceneManager.LoadScene("HardGame");    }

    

    
   
}
