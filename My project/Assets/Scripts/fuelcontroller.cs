using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelcontroller : MonoBehaviour
{
    public static fuelcontroller instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxfuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient; // Add this line

    private float _currentFuelAmount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }

    private void Start()
    {
        // _currentFuelAmount = _maxfuelAmount;
        // UpdateUI();
        
            Debug.Log("_fuelImage: " + _fuelImage);
            Debug.Log("_fuelGradient: " + _fuelGradient);

            _currentFuelAmount = _maxfuelAmount;
            UpdateUI();
        
    }
    private void Update()
    {
        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        UpdateUI();
    }
    private void UpdateUI()
    {
        _fuelImage.fillAmount = (_currentFuelAmount / _maxfuelAmount);
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }
}
