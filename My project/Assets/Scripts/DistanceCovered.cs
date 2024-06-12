using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCovered : MonoBehaviour
{
    AudioManager audioManager;

    public static DistanceCovered instance;

    [SerializeField] private TextMeshProUGUI _scoreText; // For displaying current distance or score
    [SerializeField] private TextMeshProUGUI _coinsText; // For displaying coins
    [SerializeField] private TextMeshProUGUI _highscoreText; // For displaying high score
    [SerializeField] private Transform _playerTrans;

    private Vector3 _startPos;
    private float _highscore = 0f;
    private float _distanceCovered = 0f;
    private int _totalCoinsCollected = 0;
    private bool hasHighscoreBeenBeaten = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        _startPos = _playerTrans.position;

        // Load highscore and total coins collected from CSV file
        CSVReader csvReader = FindObjectOfType<CSVReader>();
        if (csvReader != null)
        {
            (_highscore, _totalCoinsCollected) = csvReader.GetGameData("PlayerName");
            UpdateHighscoreText();
            UpdateCoinsText();
        }
        else
        {
            Debug.LogError("CSVReader script not found in scene!");
        }
    }

    void Update()
    {
        // Calculate distance covered by the player
        float distance = Mathf.Max(_playerTrans.position.x - _startPos.x, 0f);
        _distanceCovered = distance;
        _scoreText.text = "Score:" + _distanceCovered.ToString("F0") + "m";

        // Update highscore if necessary


        if (_distanceCovered > _highscore && !hasHighscoreBeenBeaten)
        {
            audioManager.PlaySFX(audioManager.highscore);
            _highscore = _distanceCovered;
            UpdateHighscoreText();
            hasHighscoreBeenBeaten = true; // Set the flag to true after the highscore is beaten
        }
    }

    private void OnApplicationQuit()
    {
        // Save highscore and total coins collected to CSV file when the game quits
        CSVReader csvReader = FindObjectOfType<CSVReader>();
        if (csvReader != null)
        {
            csvReader.UpdateGameData("PlayerName", _highscore, _totalCoinsCollected);
        }
    }

    void UpdateHighscoreText()
    {
        _highscoreText.text = "Best: " + _highscore.ToString("F0") + "m";
    }

    void UpdateCoinsText()
    {
        _coinsText.text = "+ " + _totalCoinsCollected.ToString() + "Coins";
    }

    public void AddCoins(int coins)
    {
        _totalCoinsCollected += coins;
        UpdateCoinsText();
    }

    // Method to retrieve the total coins collected
    public int GetTotalCoinsCollected()
    {
        return _totalCoinsCollected;
    }
}
