using UnityEngine;

public class Move : MonoBehaviour
{
    float Target;

    void Start()
    {
    
    }

    void Update()
    {
        Target += Time.deltaTime / 125;

        // Set the z position to a fixed value (e.g., z = 1)
        float fixedZPosition = 1f;

        // Calculate the target position with the fixed z value
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, fixedZPosition + Target);

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.05f);
    }
}
