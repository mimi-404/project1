// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class fuelcontroller : MonoBehaviour
{
    public static fuelcontroller instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxfuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;
    [SerializeField] private Rigidbody2D carRigidbody2D;
    [SerializeField] private GameObject fuelless;
    private float _currentFuelAmount;
    private DriveCar ok;
    AudioManager audioManager;
    bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        //Debug.Log("_fuelImage: " + _fuelImage);
        //Debug.Log("_fuelGradient: " + _fuelGradient);
        ok = GetComponent<DriveCar>();
        _currentFuelAmount = _maxfuelAmount;
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

    private bool _isGameOverPlayed = false; // Add this flag

    void Update()
    {
        float vehicleSpeed = ok.GetSpeed();
        if (vehicleSpeed > 1f)
        {
            _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed * vehicleSpeed;
        }
        else
        {
            _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        }

        if (_currentFuelAmount <= 0f && !_isGameOverPlayed) // Check if the flag is false
        {
            audioManager.PlaySFX(audioManager.gameOver);
            _isGameOverPlayed = true; // Set the flag to true to prevent future playback
            isGameOver = true;
            fuelless.SetActive(false);
            gamemanager.instance.GameOver();
        }
        else if (_currentFuelAmount <= _maxfuelAmount * 0.2f) // Assuming 20% is considered low fuel
        {
            fuelless.SetActive(true);
        }

        UpdateUI();
    }
    public void FillFuel()
    {
        if (_currentFuelAmount < _maxfuelAmount)
        {
            audioManager.PlaySFX(audioManager.fuelCollect);
            _currentFuelAmount = _maxfuelAmount;
            UpdateUI();
        }
    }
}