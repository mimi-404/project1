using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private TextMeshProUGUI _highscoreText;
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Start()
    {
        DisplayEndGameStats();
    }

    private void DisplayEndGameStats()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        float highscore = 0f;
        string highscoreKey = "";

        if (currentScene.name == "rushrally1")
        {
            highscoreKey = "ClassicHigh_" + currentScene.buildIndex;
        }
        else if (currentScene.name == "TimeChallenge")
        {
            highscoreKey = "TimeHigh_" + currentScene.buildIndex;
        }

        coincollector.instance.SaveCoinCount();
        highscore = PlayerPrefs.GetFloat(highscoreKey, 0f);
        int coins = PlayerPrefs.GetInt("CoinCount", 0);

        _highscoreText.text = $"High Score: {highscore:F0}m";
        _coinText.text = $"Coins: {coins}";

        float finalScore = DistanceCovered.instance.GetCurrentDistance();
        _finalScoreText.text = $"Score: {finalScore:F0}m";
    }
}
