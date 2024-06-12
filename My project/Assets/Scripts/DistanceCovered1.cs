// // // // using System.Collections;
// // // // using System.Collections.Generic;
// // // // using UnityEngine;
// // // // using TMPro;

// // // // public class DistanceCovered1 : MonoBehaviour
// // // // {
// // // //     public static DistanceCovered1 instance;

// // // //     [SerializeField] private TextMeshProUGUI _distanceText;
// // // //     [SerializeField] private TextMeshProUGUI _highscoreText;
// // // //     [SerializeField] private Transform _playerTrans;

// // // //     private Vector3 _startPos;
// // // //     private float _highscore = 0f;

// // // //     private void Awake()
// // // //     {
// // // //         instance = this;
// // // //     }

// // // //     private void Start()
// // // //     {
// // // //         _startPos = _playerTrans.position;

// // // //         // Load highscore from player prefs
// // // //         _highscore = PlayerPrefs.GetFloat("highscore", 0f);
// // // //         UpdateHighscoreText();
// // // //     }

// // // //     void Update()
// // // //     {
// // // //         // Calculate distance covered by the player
// // // //         float distance = Mathf.Max(_playerTrans.position.x - _startPos.x, 0f);

// // // //         // Update distance text
// // // //         _distanceText.text = distance.ToString("F0") + "m";

// // // //         // Update highscore
// // // //         if (distance > _highscore)
// // // //         {
// // // //             _highscore = distance;
// // // //             PlayerPrefs.SetFloat("highscore", _highscore);
// // // //             UpdateHighscoreText();
// // // //         }
// // // //     }

// // // //     void UpdateHighscoreText()
// // // //     {
// // // //         _highscoreText.text =  _highscore.ToString("F0") + "m";
// // // //     }
// // // // }
// // using UnityEngine;

// // public class DistanceCovered1 : MonoBehaviour
// // {
// //     public static DistanceCovered1 instance;

// //     private float _highscore = 0f;
// //     private float _distanceCovered = 0f;
// //     private int _totalCoinsCollected = 0;

// //     private void Awake()
// //     {
// //         instance = this;
// //     }

// //     private void Start()
// //     {
// //         // Load highscore and total coins collected from CSV file
// //         CSVReader csvReader = FindObjectOfType<CSVReader>();
// //         if (csvReader != null)
// //         {
// //             (_highscore, _totalCoinsCollected) = csvReader.GetGameData("PlayerName");
// //         }
// //         else
// //         {
// //             Debug.LogError("CSVReader script not found in scene!");
// //         }
// //     }

// //     void Update()
// //     {
// //         // Calculate distance covered by the player
// //         float distance = Mathf.Max(transform.position.x, 0f);

// //         // Update distance covered
// //         _distanceCovered += distance;

// //         // Retrieve CSVReader instance
// //         CSVReader csvReader = FindObjectOfType<CSVReader>();
// //         if (csvReader == null)
// //         {
// //             Debug.LogError("CSVReader script not found in scene!");
// //             return;
// //         }

// //         // Update highscore if necessary
// //         if (_distanceCovered > _highscore)
// //         {
// //             _highscore = _distanceCovered;
// //             // Save highscore to CSV file
// //             csvReader.UpdateGameData("PlayerName", _highscore, _totalCoinsCollected);
// //         }

// //         // Example: Increment coins collected
// //         int coinsCollectedThisGame = 100; // Example value, replace with your actual logic
// //         _totalCoinsCollected += coinsCollectedThisGame;

// //         // Save total coins collected to CSV file
// //         csvReader.UpdateGameData("PlayerName", _highscore, _totalCoinsCollected);

// //         // Reset distance/score for the next gameplay
// //         _distanceCovered = 0f;
// //     }
// // }

// using UnityEngine;

// public class DistanceCovered1 : MonoBehaviour
// {
//     private float _highscore = 0f;
//     private float _distanceCovered = 0f;
//     private int _totalCoinsCollected = 0;

//     private void Start()
//     {
//         // Load highscore and total coins collected from CSV file
//         CSVReader csvReader = FindObjectOfType<CSVReader>();
//         if (csvReader != null)
//         {
//             // Retrieve highscore and total coins from CSV file
//             (_highscore, _totalCoinsCollected) = csvReader.GetGameData("PlayerName");
//         }
//         else
//         {
//             Debug.LogError("CSVReader script not found in scene!");
//         }
//     }

//     void Update()
//     {
//         // Calculate distance covered by the player
//         float distance = Mathf.Max(transform.position.x, 0f);

//         // Update distance covered
//         _distanceCovered += distance;

//         // Retrieve CSVReader instance
//         CSVReader csvReader = FindObjectOfType<CSVReader>();
//         if (csvReader == null)
//         {
//             Debug.LogError("CSVReader script not found in scene!");
//             return;
//         }

//         // Update highscore if necessary
//         if (_distanceCovered > _highscore)
//         {
//             _highscore = _distanceCovered;
//             // Save highscore to CSV file
//             csvReader.UpdateGameData("PlayerName", _highscore, _totalCoinsCollected);
//         }

//         // Example: Increment coins collected
//         int coinsCollectedThisGame = 5; // Example value, replace with your actual logic
//         _totalCoinsCollected += coinsCollectedThisGame;

//         // Update total coins collected in CSV file
//         csvReader.UpdateGameData("PlayerName", _highscore, _totalCoinsCollected);

//         // Reset distance/score for the next gameplay
//         _distanceCovered = 0f;
//     }
// }
using UnityEngine;

public class DistanceCovered1 : MonoBehaviour
{
    private float _highscore = 0f;
    private int _totalCoinsCollected = 0;

    private void Start()
    {
        // Load highscore and total coins collected from CSV file
        CSVReader csvReader = FindObjectOfType<CSVReader>();
        if (csvReader != null)
        {
            // Retrieve highscore and total coins from CSV file
            (_highscore, _totalCoinsCollected) = csvReader.GetGameData("PlayerName");
        }
        else
        {
            Debug.LogError("CSVReader script not found in scene!");
        }
    }

    void Update()
    {
        // Calculate distance covered by the player
        float distance = Mathf.Max(transform.position.x, 0f);

        // Update highscore if necessary
        if (distance > _highscore)
        {
            _highscore = distance;
        }

        // Example: Increment coins collected
        int coinsCollectedThisGame = _totalCoinsCollected; // Example value, replace with your actual logic
        _totalCoinsCollected += coinsCollectedThisGame;
    }

    // Add a method to retrieve the total coins collected
    public int GetTotalCoinsCollected()
    {
        return _totalCoinsCollected;
    }
}

