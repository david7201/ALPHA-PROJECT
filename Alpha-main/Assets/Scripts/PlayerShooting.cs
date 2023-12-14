using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to be shot
    public Transform firePoint; // Point where the projectile will be spawned
    public float projectileForce = 20f;
    public bool isTripleShotActive = false; // Flag for triple-shot power-up

    void Update()
    {
        // Check if the "Z" key (or any desired key) is pressed to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(); // Call the Shoot method to fire a projectile
        }
    }

    void Shoot()
    {
        if (isTripleShotActive)
        {
            // Create three projectiles with slight horizontal offsets
            CreateProjectile(Vector3.left * 0.5f);
            CreateProjectile(Vector3.zero);
            CreateProjectile(Vector3.right * 0.5f);
        }
        else
        {
            // Create a single projectile
            CreateProjectile(Vector3.zero);
        }
    }

    // Method to create a projectile
    void CreateProjectile(Vector3 offset)
    {
        // Instantiate a new projectile at the firePoint position with an offset and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position + offset, firePoint.rotation);
        
        // Get the Rigidbody component of the projectile
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        
        // Apply force to the projectile in the upward direction only
        projectileRigidbody.AddForce(Vector3.up * projectileForce, ForceMode.Impulse);
        
        // Destroy the projectile after 3 seconds
        Destroy(newProjectile, 3f);
    }

    // Public method to activate the triple-shot power-up
    public void ActivateTripleShot()
    {
        isTripleShotActive = true;
        // Start the coroutine to deactivate the power-up after 5 seconds
        StartCoroutine(DeactivateTripleShot());
    }

    // Coroutine to deactivate the triple-shot power-up
    private IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(10f); // Power-up lasts for 5 seconds
        isTripleShotActive = false;
    }
    
}
