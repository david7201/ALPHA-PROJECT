using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float minY = -9f;
    public float maxY = 3f;
    public float minX = -11f;
    public float maxX = 14f;

    public GameOverManager gameOverManager;
    public AudioSource gameOverAudio; 

    void Start()
    {
        transform.position = new Vector3(2f, -8f, 0f);

        Rigidbody playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.useGravity = false;

        playerRigidbody.freezeRotation = true;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            PlayGameOverSound();

            ScoreManager.instance.GameOver();
            Destroy(gameObject);
        }
    }

    void PlayGameOverSound()
    {
        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }
    }
}
