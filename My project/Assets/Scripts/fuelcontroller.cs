// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelcontroller : MonoBehaviour
{
    public static fuelcontroller instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxfuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;
    [SerializeField] private Rigidbody2D carRigidbody2D;
    private float _currentFuelAmount;
    private DriveCar ok;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //Debug.Log("_fuelImage: " + _fuelImage);
        //Debug.Log("_fuelGradient: " + _fuelGradient);
        ok = GetComponent<DriveCar>();
        _currentFuelAmount = _maxfuelAmount;
        UpdateUI();
    }

    private void Update()
    {
        float vehicleSpeed = ok.GetSpeed();

        if (carRigidbody2D.velocity != Vector2.zero) // The car is moving
        {
            _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed * vehicleSpeed;
        }
        else
        {
            _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        }

        if (_currentFuelAmount <= 0f)
        {
            gamemanager.instance.GameOver();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        float fillAmount = (_currentFuelAmount / _maxfuelAmount);

        if (_fuelImage.fillAmount != fillAmount)
        {
            _fuelImage.fillAmount = fillAmount;
            _fuelImage.color = _fuelGradient.Evaluate(fillAmount);
        }
    }

    public void FillFuel()
    {
        if (_currentFuelAmount < _maxfuelAmount)
        {
            _currentFuelAmount = _maxfuelAmount;
            UpdateUI();
        }
    }
}
// // using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class fuelcontroller : MonoBehaviour
// {
//     public static fuelcontroller instance;

//     [SerializeField] private Image _fuelImage;
//     [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
//     [SerializeField] private float _maxfuelAmount = 100f;
//     [SerializeField] private Gradient _fuelGradient;
//     [SerializeField] private Rigidbody2D carRigidbody2D;
//     private float _currentFuelAmount;
//     private DriveCar ok;
//     private float _gameStartTime;
//     [SerializeField] private float _startDelay = 2f; // The delay before the fuel starts draining

//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this; 
//         }
//     }

//     private void Start()
//     {
//         Debug.Log("_fuelImage: " + _fuelImage);
//         Debug.Log("_fuelGradient: " + _fuelGradient);
//         ok = GetComponent<DriveCar>();
//         _currentFuelAmount = _maxfuelAmount;
//         _gameStartTime = Time.time;
//         UpdateUI();
//     }

//     private void Update()
//     {   
//         if (Time.time - _gameStartTime > _startDelay)
//         {
//             float vehicleSpeed = ok.GetSpeed();

//             if (carRigidbody2D.velocity != Vector2.zero) // The car is moving
//             {
//                 _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed * vehicleSpeed;
//             }
//             else
//             {
//                 _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
//             }

//             if (_currentFuelAmount <= 0f)
//             {
//                 gamemanager.instance.GameOver();
//             }

//             UpdateUI();
//         }
//     }

//     private void UpdateUI()
//     {
//         float fillAmount = (_currentFuelAmount / _maxfuelAmount);

//         if (_fuelImage.fillAmount != fillAmount)
//         {
//             _fuelImage.fillAmount = fillAmount;
//             _fuelImage.color = _fuelGradient.Evaluate(fillAmount);
//         }
//     }

//     public void FillFuel()
//     {
//         if (_currentFuelAmount < _maxfuelAmount)
//         {
//             _currentFuelAmount = _maxfuelAmount;
//             UpdateUI();
//         }
//     }
// }