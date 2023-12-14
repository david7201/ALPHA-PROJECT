using UnityEngine;

public class Monster : MonoBehaviour
{
    // Define an event for when the monster is destroyed
    // Define an event for when the monster is destroyed
    public event System.Action MonsterDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is either the player or a capsule
        if (other.CompareTag("Player") || other.CompareTag("Capsule"))
        {
            DestroyMonster();
        }
    }

    // Call this method when the monster is destroyed
    public void DestroyMonster()
    {
        // Perform any cleanup or additional logic here

        // Raise the MonsterDestroyed event
        MonsterDestroyed?.Invoke();

        // Destroy the GameObject
        Destroy(gameObject);
    }
    void Start()
{
    // Set the spaceship rotation to 90 degrees on the X axis
    transform.eulerAngles = new Vector3(90f, 0f, 0f);

    // Fix the spaceship's Z position to 0
    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
}

}
