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

        float fixedZPosition = 1f;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, fixedZPosition + Target);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.05f);
    }
}
