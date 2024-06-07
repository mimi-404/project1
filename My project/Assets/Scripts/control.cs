
// using UnityEngine;

// public class Control : MonoBehaviour
// {
//     public Transform target;
//     public Vector3 offset;
//     public float smoothSpeed = 0.125f;
//     public float minY = -10f;
//     public float maxY = 10f;

//     private float orthographicHalfHeight;
//     private DriveCar driveCar;
//     private bool isGameOver = false;

//     // Additional fields for zoom effect
//     public Animation cameraAnimation;
//     public float zoomDuration = 5f;
//     private bool isZooming = false;

//     void Start()
//     {
//         if (target == null)
//         {
//             Debug.LogError("Target is not assigned in the inspector!");
//             return;
//         }

//         if (offset == Vector3.zero)
//         {
//             offset = transform.position - target.position;
//         }

//         orthographicHalfHeight = Camera.main.orthographicSize;
//         driveCar = target.GetComponent<DriveCar>();
//     }

//     void LateUpdate()
//     {
//         if (isGameOver)
//             return;

//         if (target == null || driveCar == null)
//             return;

//         float carSpeed = driveCar.GetSpeed();
//         float dynamicSmoothSpeed = Mathf.Lerp(smoothSpeed, smoothSpeed + carSpeed * 0.01f, Time.deltaTime);

//         Vector3 desiredPosition = target.position + offset;
//         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, dynamicSmoothSpeed);

//         float clampedY = Mathf.Clamp(smoothedPosition.y, minY + orthographicHalfHeight, maxY - orthographicHalfHeight);
//         smoothedPosition.y = clampedY;

//         transform.position = smoothedPosition;
//     }

//     public void GameOver()
//     {
//         if (isGameOver || isZooming)
//             return;

//         isGameOver = true;

//         // Play the zoom animation
//         if (cameraAnimation != null)
//         {
//             isZooming = true;
//             cameraAnimation.Play("ZoomAnimation");
//             Invoke("ResetZoom", zoomDuration); // Reset the zoom effect after duration
//         }

//         // You can also add code here to trigger sound effects and particle effects
//     }

//     void ResetZoom()
//     {
//         isZooming = false;
//     }
// }
using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
    private Camera mainCamera;

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float minY = -10f;
    public float maxY = 10f;

    private float orthographicHalfHeight;
    private DriveCar driveCar;
    private bool isGameOver = false;

    // Additional fields for zoom effect
    public float zoomDuration = 1.5f;
    private Vector3 initialPosition;
    private bool isZooming = false;

    void Start()
    {
        mainCamera = Camera.main; // Get a reference to the main camera
        if (target == null)
        {
            Debug.LogError("Target is not assigned in the inspector!");
            return;
        }

        if (offset == Vector3.zero)
        {
            offset = transform.position - target.position;
        }

        orthographicHalfHeight = Camera.main.orthographicSize;
        driveCar = target.GetComponent<DriveCar>();
    }

    void LateUpdate()
    {
        if (isGameOver || isZooming)
            return;

        if (target == null || driveCar == null)
            return;

        float carSpeed = driveCar.GetSpeed();
        float dynamicSmoothSpeed = Mathf.Lerp(smoothSpeed, smoothSpeed + carSpeed * 0.01f, Time.deltaTime);

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, dynamicSmoothSpeed);

        float clampedY = Mathf.Clamp(smoothedPosition.y, minY + orthographicHalfHeight, maxY - orthographicHalfHeight);
        smoothedPosition.y = clampedY;

        transform.position = smoothedPosition;
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        // Start the smooth zoom-in effect
        StartZoomEffect();
    }

    IEnumerator ZoomIn()
    {
        yield return null;
        float elapsedTime = 0;

        while (elapsedTime < zoomDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, target.position, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera reaches the target position
        transform.position = target.position;

        // Enable the image canvases or perform any other post-zoom actions
        // For example, you can enable the game over canvas here
        // gameOverCanvas.SetActive(true);

        // Reset zooming flag
        isZooming = false;
    }

    public void StartZoomEffect()
    {
        if (!isGameOver && !isZooming)
        {
            isZooming = true;
            StartCoroutine(ZoomIn());
        }
    }
}
