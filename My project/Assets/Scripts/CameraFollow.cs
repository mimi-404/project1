
// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     [SerializeField] private Transform Layer_0; // Assign this in the inspector
//     [SerializeField] private Vector3 offset; // You can adjust this in the inspector

//     private void Update()
//     {
//         if (Layer_0 != null)
//         {
//             Vector3 newPosition = new Vector3(Layer_0.position.x + offset.x, transform.position.y, transform.position.z);
//             transform.position = newPosition;
//         }
//     }
// }
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public DriveCar vehicle;
 
    public Vector3 offset = new Vector3(10f, 0f, 0f);

    private void LateUpdate()
    {   
        if (target == null)
        {
            Debug.LogError("Target is not set");
            return;
        }
        float smoothSpeed = vehicle.GetSpeed() * 1.2f;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}