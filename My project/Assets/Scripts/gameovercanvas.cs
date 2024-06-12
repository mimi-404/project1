// using UnityEngine;
// using TMPro;

// public class GameOverCanvas : MonoBehaviour
// {
//     [SerializeField] private TextMeshProUGUI coinsText;
//     [SerializeField] private TextMeshProUGUI distanceText;
//     [SerializeField] private TextMeshProUGUI highscoreText;

//     void Start()
//     {
//         // Example values for score and distance (replace with your actual values)
//         float coins = 0f;
//         float distance = 0f;
//         coinsText.text = coins.ToString() + "+ Coins ";
//         // Update score and distance text fields
//         distanceText.text = "Distance: " + distance.ToString() + "m";

//         // Retrieve highscore from CSVReader script
//         CSVReader csvReader = FindObjectOfType<CSVReader>();
//         if (csvReader != null)
//         {
//             float highscore = csvReader.GetHighscore();
//             highscoreText.text = "Best: " + highscore.ToString() + "m";
//         }
//         else
//         {
//             Debug.LogError("CSVReader script not found in scene!");
//         }
//     }
// }

using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    void Start()
    {
        // Retrieve CSVReader instance
        CSVReader csvReader = FindObjectOfType<CSVReader>();
        if (csvReader != null)
        {
            // Retrieve highscore from CSV file
            (float highscore, _) = csvReader.GetGameData("PlayerName");
            Debug.Log("Highscore: " + highscore);
        }
        else
        {
            Debug.LogError("CSVReader script not found in scene!");
        }
    }
}
