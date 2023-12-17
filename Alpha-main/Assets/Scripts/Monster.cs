using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool destroyedByCapsule = false;
    private int health;

    private void Start()
    {

        transform.eulerAngles = new Vector3(90f, 0f, 0f);

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
        health--; 
        Debug.Log(gameObject.name + " hit! Health now: " + health);

        if (health <= 0)
        {
            Debug.Log(gameObject.name + " destroyed!");
            destroyedByCapsule = true; 
            ScoreManager.instance.AddScore(10); 
            Destroy(gameObject); 
        }
    }
    else if (other.CompareTag("Player"))
    {
        ScoreManager.instance.GameOver(); 
        Destroy(other.gameObject); 
    }
    else if (other.CompareTag("Plane")) 
    {
        Debug.Log(gameObject.name + " hit the plane and is being destroyed!");
        Destroy(gameObject);
    }
}


        
    

    public void DestroyMonster()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (!destroyedByCapsule)
        {
            ScoreManager.instance.SubtractScore(5);
        }
    }

    
}
