using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCovered1 : MonoBehaviour
{
    public static DistanceCovered1 instance;

    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _highscoreText;
    [SerializeField] private Transform _playerTrans;

    private Vector3 _startPos;
    private float _highscore = 0f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _startPos = _playerTrans.position;

        // Load highscore from player prefs
        _highscore = PlayerPrefs.GetFloat("highscore", 0f);
        UpdateHighscoreText();
    }

    void Update()
    {
        // Calculate distance covered by the player
        float distance = Mathf.Max(_playerTrans.position.x - _startPos.x, 0f);

        // Update distance text
        _distanceText.text = distance.ToString("F0") + "m";

        // Update highscore
        if (distance > _highscore)
        {
            _highscore = distance;
            PlayerPrefs.SetFloat("highscore", _highscore);
            UpdateHighscoreText();
        }
    }

    void UpdateHighscoreText()
    {
        _highscoreText.text =  _highscore.ToString("F0") + "m";
    }
}
