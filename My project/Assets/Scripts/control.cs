// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Control : MonoBehaviour
// {
//     public Transform target;
//     public Vector3 offset;
//     public float smoothSpeed = 0.125f;

//     // Start is called before the first frame update
//     void Start()
//     {
//         if (target == null)
//         {
//             Debug.LogError("Target is not assigned in the inspector!");
//             return;
//         }

//         // Calculate the initial offset if it's not set manually
//         if (offset == Vector3.zero)
//         {
//             offset = transform.position - target.position;
//         }
//     }

//     // Update is called once per frame
//     void LateUpdate()
//     {
//         if (target == null) return;

//         Vector3 desiredPosition = target.position + offset;
//         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//         transform.position = smoothedPosition;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float minY = -10f; // Minimum y position
    public float maxY = 10f;  // Maximum y position
    private float orthographicHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target is not assigned in the inspector!");
            return;
        }

        // Calculate the initial offset if it's not set manually
        if (offset == Vector3.zero)
        {
            offset = transform.position - target.position;
        }

        // Calculate half of the camera's orthographic size
        orthographicHalfHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Clamp the y position within the specified range adjusted for the orthographic size
        float clampedY = Mathf.Clamp(smoothedPosition.y, minY + orthographicHalfHeight, maxY - orthographicHalfHeight);
        smoothedPosition.y = clampedY;

        transform.position = smoothedPosition;
    }
}


