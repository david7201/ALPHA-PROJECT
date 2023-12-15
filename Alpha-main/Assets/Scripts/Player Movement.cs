using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed

    // Define boundaries for player movement
    public float minY = -9f;
    public float maxY = 3f;
    public float minX = -11f;
    public float maxX = 14f;

    void Start()
    {
        // Set the initial position of the player
        transform.position = new Vector3(2f, -8f, 0f);

        // Disable gravity for the player Rigidbody
        Rigidbody playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.useGravity = false;

        // Lock rotation to prevent spinning
        playerRigidbody.freezeRotation = true;
    }

    void Update()
    {
        // Check for player input to move
        MovePlayer();
    }

    void MovePlayer()
{
    // Get horizontal and vertical input
    float horizontalInput = Input.GetAxisRaw("Horizontal");
    float verticalInput = Input.GetAxisRaw("Vertical");

    // Calculate the movement direction
    Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

    // Apply the movement
    transform.position += movement * moveSpeed * Time.deltaTime;

    // Clamp the player's position within the specified boundaries
    float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
    float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

    // Update the player's position after clamping
    transform.position = new Vector3(clampedX, clampedY, 0f);
}

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            ScoreManager.instance.GameOver(); // Game over
            Destroy(gameObject); // Destroy the player
        }
    }
}
