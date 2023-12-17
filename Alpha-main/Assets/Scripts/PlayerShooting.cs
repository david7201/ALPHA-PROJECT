using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint; 
    public float projectileForce = 20f;
    public bool isTripleShotActive = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(); 
        }
    }

    void Shoot()
    {
        if (isTripleShotActive)
        {
            CreateProjectile(Vector3.left * 0.5f);
            CreateProjectile(Vector3.zero);
            CreateProjectile(Vector3.right * 0.5f);
        }
        else
        {
            CreateProjectile(Vector3.zero);
        }
    }

    void CreateProjectile(Vector3 offset)
    {
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position + offset, firePoint.rotation);
        
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        
        projectileRigidbody.AddForce(Vector3.up * projectileForce, ForceMode.Impulse);
        
        Destroy(newProjectile, 3f);
    }

    public void ActivateTripleShot()
    {
        isTripleShotActive = true;
        StartCoroutine(DeactivateTripleShot());
    }

    private IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(10f);
        isTripleShotActive = false;
    }
    
}
