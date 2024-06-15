using UnityEngine;

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
        if (isGameOver)
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

    }
}

