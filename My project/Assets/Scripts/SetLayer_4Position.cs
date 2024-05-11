using UnityEngine;

public class SetLayer4Position : MonoBehaviour
{
    void Start()
    {
        // Get the current position of Layer_4
        Vector3 currentPosition = transform.position;

        // Set the Y position to -7
        currentPosition.y = -7f;

        // Assign the new position to Layer_4
        transform.position = currentPosition;
    }
}
