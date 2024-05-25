
// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     public Transform target;
//     public DriveCar vehicle;
 
//     public Vector3 offset = new Vector3(10f, 0f, 0f);

//     private void LateUpdate()
//     {   
//         if (target == null)
//         {
//             Debug.LogError("Target is not set");
//             return;
//         }
//         float smoothSpeed = vehicle.GetSpeed() * 1.2f;
//         Vector3 desiredPosition = target.position + offset;
//         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//         transform.position = smoothedPosition;
//     }
// }
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform carTransform;
    public Vector3 offset;

    private void Update()
    {
        transform.position = new Vector3(carTransform.position.x + offset.x, carTransform.position.y + offset.y, offset.z);
    }
}