// // using UnityEngine;
// // using System;
// // using System.IO;

// // public class CSVReader : MonoBehaviour
// // {
// //     [SerializeField] private TextAsset csvText; // Reference to the CSV file as a TextAsset

// //     private string[] lines; // Array to store lines from the CSV file

// //     void Start()
// //     {
// //         if (csvText != null)
// //         {
// //             // Split the CSV file into lines
// //             lines = csvText.text.Split('\n');
// //         }
// //         else
// //         {
// //             Debug.LogError("CSV file not assigned in the Inspector!");
// //         }
// //     }

// //     // Method to read data from CSV file
// //     public (float highscore, int totalCoins) GetGameData(string playerName)
// //     {
// //         float highscore = 0f;
// //         int totalCoins = 0;

// //         if (lines != null)
// //         {
// //             // Find the line corresponding to the player
// //             foreach (string line in lines)
// //             {
// //                 string[] data = line.Split(',');
// //                 if (data.Length >= 3 && data[0] == playerName)
// //                 {
// //                     float.TryParse(data[1], out highscore);
// //                     int.TryParse(data[2], out totalCoins);
// //                     break;
// //                 }
// //             }
// //         }
// //         else
// //         {
// //             Debug.LogWarning("No data to read. CSV file may not have been loaded.");
// //         }

// //         return (highscore, totalCoins);
// //     }

// //     // Method to update data in CSV file
// //     public void UpdateGameData(string playerName, float newHighscore, int newTotalCoins)
// //     {
// //         // Update the lines array with the new data
// //         if (lines != null)
// //         {
// //             bool playerFound = false;

// //             for (int i = 0; i < lines.Length; i++)
// //             {
// //                 string[] data = lines[i].Split(',');
// //                 if (data.Length >= 3 && data[0] == playerName)
// //                 {
// //                     lines[i] = string.Format("{0},{1},{2}", playerName, newHighscore, newTotalCoins);
// //                     playerFound = true;
// //                     break;
// //                 }
// //             }

// //             // If player not found, add a new entry
// //             if (!playerFound)
// //             {
// //                 Array.Resize(ref lines, lines.Length + 1);
// //                 lines[lines.Length - 1] = string.Format("{0},{1},{2}", playerName, newHighscore, newTotalCoins);
// //             }
// //         }
// //         else
// //         {
// //             Debug.LogWarning("No data to update. CSV file may not have been loaded.");
// //         }
// //     }
// // }
// using UnityEngine;
// using System;

// public class CSVReader : MonoBehaviour
// {
//     [SerializeField] private TextAsset csvText; // Reference to the CSV file as a TextAsset

//     private string[] lines; // Array to store lines from the CSV file

//     void Start()
//     {
//         if (csvText != null)
//         {
//             // Split the CSV file into lines
//             lines = csvText.text.Split('\n');
//         }
//         else
//         {
//             Debug.LogError("CSV file not assigned in the Inspector!");
//         }
//     }

//     // Method to read data from CSV file
//     public (float highscore, int totalCoins) GetGameData(string playerName)
//     {
//         float highscore = 0f;
//         int totalCoins = 0;

//         if (lines != null)
//         {
//             // Find the line corresponding to the player
//             foreach (string line in lines)
//             {
//                 string[] data = line.Split(',');
//                 if (data.Length >= 5 && data[0] == playerName)
//                 {
//                     float.TryParse(data[1], out highscore);
//                     int.TryParse(data[2], out totalCoins);
//                     break;
//                 }
//             }
//         }
//         else
//         {
//             Debug.LogWarning("No data to read. CSV file may not have been loaded.");
//         }

//         return (highscore, totalCoins);
//     }

//     // Method to update data in CSV file
//     public void UpdateGameData(string playerName, float newHighscore, int newTotalCoins)
//     {
//         // Update the lines array with the new data
//         if (lines != null)
//         {
//             bool playerFound = false;

//             for (int i = 0; i < lines.Length; i++)
//             {
//                 string[] data = lines[i].Split(',');
//                 if (data.Length >= 5 && data[0] == playerName)
//                 {
//                     lines[i] = string.Format("{0},{1},{2}", playerName, newHighscore, newTotalCoins);
//                     playerFound = true;
//                     break;
//                 }
//             }

//             // If player not found, add a new entry
//             if (!playerFound)
//             {
//                 Array.Resize(ref lines, lines.Length + 1);
//                 lines[lines.Length - 1] = string.Format("{0},{1},{2}", playerName, newHighscore, newTotalCoins);
//             }
//         }
//         else
//         {
//             Debug.LogWarning("No data to update. CSV file may not have been loaded.");
//         }
//     }
// }

using UnityEngine;
using System;
public class CSVReader : MonoBehaviour
{
    [SerializeField] private TextAsset csvText; // Reference to the CSV file as a TextAsset

    private string[] lines; // Array to store lines from the CSV file

    void Start()
    {
        if (csvText != null)
        {
            // Split the CSV file into lines
            lines = csvText.text.Split('\n');
        }
        else
        {
            Debug.LogError("CSV file not assigned in the Inspector!");
        }
    }

    // Method to read data from CSV file
    // public (float highscore, int totalCoins) GetGameData(string playerName)
    // {
    //     float highscore = 0f;
    //     int totalCoins = 0;

    //     if (lines != null)
    //     {
    //         // Find the line corresponding to the player
    //         foreach (string line in lines)
    //         {
    //             string[] data = line.Split(',');
    //             if (data.Length >= 5 && data[0] == playerName)
    //             {
    //                 float.TryParse(data[1], out highscore);
    //                 int.TryParse(data[2], out totalCoins);
    //                 break;
    //             }
    //         }
    //     }
    //     else
    //     {
    //         Debug.LogWarning("No data to read. CSV file may not have been loaded.");
    //     }

    //     return (highscore, totalCoins);
    // }
    // Method to read data from CSV file
    public (float highscore, int totalCoins) GetGameData(string playerName)
    {
        float highscore = 0f;
        int totalCoins = 0;

        if (lines != null)
        {
            // Find the line corresponding to the player
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length >= 3 && data[0] == playerName)
                {
                    float.TryParse(data[1], out highscore);
                    int.TryParse(data[2], out totalCoins);
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning("No data to read. CSV file may not have been loaded.");
        }

        return (highscore, totalCoins);
    }


    // Method to update data in CSV file
    public void UpdateGameData(string playerName, float newHighscore, int newTotalCoins)
    {
        // Update the lines array with the new data
        if (lines != null)
        {
            bool playerFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                if (data.Length >= 5 && data[0] == playerName)
                {
                    lines[i] = string.Format("{0},{1},{2},{3},{4}", playerName, newHighscore, newTotalCoins, data[3], data[4]);
                    playerFound = true;
                    break;
                }
            }

            // If player not found, add a new entry
            if (!playerFound)
            {
                Array.Resize(ref lines, lines.Length + 1);
                lines[lines.Length - 1] = string.Format("{0},{1},{2},0,0", playerName, newHighscore, newTotalCoins);
            }
        }
        else
        {
            Debug.LogWarning("No data to update. CSV file may not have been loaded.");
        }
    }
}
