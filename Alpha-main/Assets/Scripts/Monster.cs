using UnityEngine;

public class Monster : MonoBehaviour
{
    // Flag to track if the monster was destroyed by a capsule
    private bool destroyedByCapsule = false;
    private int health;

    private void Start()
    {

        // Set the spaceship rotation to 90 degrees on the X axis
        transform.eulerAngles = new Vector3(90f, 0f, 0f);

        // Fix the spaceship's Z position to 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    public void InitializeHealth(int initialHealth)
    {
        health = initialHealth;
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Capsule"))
    {
        health--; // Decrement health when hit by a capsule
        Debug.Log(gameObject.name + " hit! Health now: " + health);

        if (health <= 0)
        {
            Debug.Log(gameObject.name + " destroyed!");
            destroyedByCapsule = true; // Flag that it was hit by a capsule
            ScoreManager.instance.AddScore(10); // Add score only when monster is destroyed
            Destroy(gameObject); // Destroy the monster if health is depleted
        }
    }
    else if (other.CompareTag("Player"))
    {
        // Logic for what happens when a monster collides with the player
        ScoreManager.instance.GameOver(); // Trigger game over
        Destroy(other.gameObject); // Destroy the player
    }
    else if (other.CompareTag("Plane")) // Make sure the plane has this tag assigned
    {
        // If the monster collides with the plane, destroy the monster
        Debug.Log(gameObject.name + " hit the plane and is being destroyed!");
        Destroy(gameObject);
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
