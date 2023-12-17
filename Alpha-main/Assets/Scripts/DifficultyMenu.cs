using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    public Button EasyButton;
    public Button MediumButton;
    public Button HardButton;

    public static DifficultyManager instance;

    


    void Start()
    {
        EasyButton.onClick.AddListener(OnEasyButtonClick);
        MediumButton.onClick.AddListener(OnMediumButtonClick);
        HardButton.onClick.AddListener(OnHardButtonClick);
    }

    void OnEasyButtonClick()
    {
        Debug.Log("Easy difficulty selected!");

        SceneManager.LoadScene("EasyGame"); 
    }

    void OnMediumButtonClick()
    {
        Debug.Log("Medium difficulty selected!");

        SceneManager.LoadScene("MediumGame"); 
    }

    void OnHardButtonClick()
    {
        Debug.Log("Hard difficulty selected!");

        SceneManager.LoadScene("HardGame");    }

    

    
   
}
