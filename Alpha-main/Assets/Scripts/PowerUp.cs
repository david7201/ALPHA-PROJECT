using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10f); 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            ActivatePowerUp();
            Destroy(gameObject); 
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
