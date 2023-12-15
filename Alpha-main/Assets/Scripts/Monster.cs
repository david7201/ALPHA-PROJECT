using UnityEngine;

public class Monster : MonoBehaviour
{
    // Flag to track if the monster was destroyed by a capsule
    private bool destroyedByCapsule = false;

    private void Start()
    {
        // Set the spaceship rotation to 90 degrees on the X axis
        transform.eulerAngles = new Vector3(90f, 0f, 0f);

        // Fix the spaceship's Z position to 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the monster is hit by a capsule
        if (other.CompareTag("Capsule"))
        {
            destroyedByCapsule = true;
            ScoreManager.instance.AddScore(10); // Add score
            DestroyMonster(); // Destroy the monster
        }
        // Check if the monster collides with the player
        else if (other.CompareTag("Player"))
        {
            ScoreManager.instance.GameOver(); // Game over
            Destroy(other.gameObject); // Destroy the player
        }
    }

    // Call this method when the monster is destroyed
    public void DestroyMonster()
    {
        // Destroy the GameObject
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // Subtract score if the monster was not destroyed by a capsule
        if (!destroyedByCapsule)
        {
            ScoreManager.instance.SubtractScore(5);
        }
    }
}
