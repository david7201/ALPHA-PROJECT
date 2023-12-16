using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public int monsterHealth = 1; // Default health for monsters
    public bool infiniteWaves = false; // Should waves be infinite

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Ensures there is only one instance
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Makes this object persistent across scene changes
        }
    }
    
    // Add any other methods related to difficulty settings here
}
