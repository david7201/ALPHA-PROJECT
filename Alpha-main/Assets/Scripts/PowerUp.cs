using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10f); // Destroy after 10 seconds
    }

    private void OnTriggerEnter(Collider other) // Use OnTriggerEnter2D for 2D
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            ActivatePowerUp();
            Destroy(gameObject); // Destroy the power-up
        }
    }

    private void ActivatePowerUp()
    {
        PlayerShooting playerShooting = FindObjectOfType<PlayerShooting>();
        if (playerShooting != null)
        {
            playerShooting.ActivateTripleShot();
        }
    }
}
