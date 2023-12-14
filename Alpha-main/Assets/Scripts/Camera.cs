using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public float minY = -9f;
    public float maxY = 3f;
    public float minX = -11f;
    public float maxX = 14f;

    void Start()
    {
        // Calculate the center of the specified coordinates
        float centerX = (minX + maxX) / 2;
        float centerY = (minY + maxY) / 2;

        // Set the camera position
        transform.position = new Vector3(centerX, centerY, transform.position.z);

        // Calculate the required orthographic size
        float verticalExtent = (maxY - minY) / 2;
        Camera.main.orthographicSize = verticalExtent;

        // Adjust the aspect ratio
        float horizontalExtent = (maxX - minX) / 2;
        float desiredAspect = horizontalExtent / verticalExtent;
        Camera.main.aspect = desiredAspect;
    }
}
