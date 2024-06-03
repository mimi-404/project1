// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DriveCar : MonoBehaviour
// {
//     [SerializeField] private Rigidbody2D _frontTireRB;
//     [SerializeField] private Rigidbody2D _backTireRB;
//     [SerializeField] private Rigidbody2D _carRb;
//     [SerializeField] private float _speed = 150f;
//     [SerializeField] private float _rotationspeed = 300f;

//     private float _moveInput;
//      public float GetSpeed()
//     {
//         //return _speed;
//         return _carRb.velocity.magnitude;
//     }

//     private void Update()
//     {
//         _moveInput = Input.GetAxisRaw("Horizontal");
//     }
//     private void FixedUpdate()
//     {
//         _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
//         _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
//         _carRb.AddTorque(_moveInput * _rotationspeed * Time.fixedDeltaTime);

//     }

// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRb;
    [SerializeField] private float _baseSpeed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;
    [SerializeField] private float _speedIncrement = 10f; // Speed increment per second

    private float _moveInput;
    private float _currentSpeed;

    void Start()
    {
        _currentSpeed = _baseSpeed;
    }

    public float GetSpeed()
    {
        return _carRb.velocity.magnitude;
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // Increment the speed over time
        _currentSpeed += _speedIncrement * Time.fixedDeltaTime;

        // Debug to see the current speed value
        // Debug.Log("Current Speed: " + _currentSpeed);

        // Apply torque to the tires
        _frontTireRB.AddTorque(-_moveInput * _currentSpeed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _currentSpeed * Time.fixedDeltaTime);

        // Apply torque to the car body for rotation
        _carRb.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }
}


