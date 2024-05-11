using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 _initialOffset;

    private void Start()
    {
        _initialOffset = transform.position - cameraTransform.position;
    }

    private void Update()
    {
        transform.position = cameraTransform.position + _initialOffset;
    }
}