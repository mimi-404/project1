// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground_0 : MonoBehaviour
{
    public bool Camera_Move;
    public float Camera_MoveSpeed = 1.5f;
    [Header("Layer Setting")]
    public float[] Layer_Speed = new float[10];
    public GameObject[] Layer_Objects = new GameObject[10];

    private Transform _camera;
    private float[] startPos = new float[10];
    private float boundSizeX;

    // New variables
    public float backgroundSize; // The width of your background
    private int leftIndex;
    private int rightIndex;

    private void Start()
    {
        _camera = Camera.main.transform;
        for (int i = 0; i < Layer_Objects.Length; i++)
        {
            startPos[i] = Layer_Objects[i].transform.position.x;
        }

        leftIndex = 0;
        rightIndex = Layer_Objects.Length - 1;
    }

    private void Update()
    {
        if (Camera_Move)
        {
            _camera.transform.Translate(Vector3.right * Time.deltaTime * Camera_MoveSpeed);
        }

        for (int i = 0; i < Layer_Objects.Length; i++)
        {
            Layer_Objects[i].transform.position = new Vector3(startPos[i] + _camera.position.x * Layer_Speed[i], Layer_Objects[i].transform.position.y, Layer_Objects[i].transform.position.z);
        }

        // New code
        if (_camera.position.x - transform.position.x > Layer_Objects[leftIndex].transform.position.x + boundSizeX)
            ScrollRight();
    }

    // New method
    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        Layer_Objects[leftIndex].transform.position = new Vector3(Layer_Objects[rightIndex].transform.position.x + backgroundSize, Layer_Objects[leftIndex].transform.position.y, Layer_Objects[leftIndex].transform.position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == Layer_Objects.Length)
            leftIndex = 0;
    }
}