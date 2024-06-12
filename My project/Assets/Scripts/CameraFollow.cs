
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