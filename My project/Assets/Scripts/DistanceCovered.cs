using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DistanceCovered : MonoBehaviour
{
    AudioManager audioManager;

    public static DistanceCovered instance;

    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _highscoreText;
    [SerializeField] private Transform _playerTrans;

    private Vector3 _startPos;
    private float _classicHighscore = 0f;
    private float _timeHighscore = 0f;
    private float _distanceCovered = 0f;
    private bool _beathighscore = false;

    private void Awake()
    {
        _startPos = _playerTrans.position;
        instance = this;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        _startPos = _playerTrans.position;

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "rushrally1")
        {
            _classicHighscore = PlayerPrefs.GetFloat("ClassicHigh_" + currentScene.buildIndex, 0f);
            UpdateHighscoreText(_classicHighscore);
        }
        else if (currentScene.name == "TimeChallenge")
        {
            _timeHighscore = PlayerPrefs.GetFloat("TimeHigh_" + currentScene.buildIndex, 0f);
            UpdateHighscoreText(_timeHighscore);
        }
    }

    void Update()
    {
        float distance = Mathf.Max(_playerTrans.position.x - _startPos.x, 0f);
        _distanceText.text = distance.ToString("F0") + "m";

        if (distance > GetCurrentHighscore())
        {
            Scene currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "rushrally1")
            {
                _classicHighscore = distance;
                PlayerPrefs.SetFloat("ClassicHigh_" + currentScene.buildIndex, _classicHighscore);
                UpdateHighscoreText(_classicHighscore);
            }
            else if (currentScene.name == "TimeChallenge")
            {
                _timeHighscore = distance;
                PlayerPrefs.SetFloat("TimeHigh_" + currentScene.buildIndex, _timeHighscore);
                UpdateHighscoreText(_timeHighscore);
            }

            if (!_beathighscore)
            {
                audioManager.PlaySFX(audioManager.highscore);
                _beathighscore = true;
            }
        }
    }

    void UpdateHighscoreText(float highscore)
    {
        _highscoreText.text = highscore.ToString("F0") + "m";
    }

    float GetCurrentHighscore()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "rushrally1")
        {
            return _classicHighscore;
        }
        else if (currentScene.name == "TimeChallenge")
        {
            return _timeHighscore;
        }

        return 0f;
    }
    public float GetCurrentDistance()
    {
        return Mathf.Max(_playerTrans.position.x - _startPos.x, 0f);
    }
}

