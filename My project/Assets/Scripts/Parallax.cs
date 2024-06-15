
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    private float length;
    public GameObject cam; // Reference to the main camera
    public float parallaxEffect; // Factor to control the parallax effect

    void Start()
    {
        startPos = transform.position.x; // Initial position of the background
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Width of the background sprite
    }

    void LateUpdate()
    {
        float camPosX = cam.transform.position.x; // Current camera position on x-axis
        float dist = camPosX * parallaxEffect; // Distance to move based on the parallax effect

        // Update the position of the background (only along the x-axis)
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        // Calculate temporary position to check looping
        float temp = camPosX * (1 - parallaxEffect);

        // Adjust the start position to create a looping effect
        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
