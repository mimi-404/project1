using UnityEngine;
using TMPro;

public class TimeChallenge : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;
    public TMP_Text timerText;
    public GameObject vehicle;
    private Vector3 startPosition;
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    void Start()
    {
        if (vehicle != null)
        {
            startPosition = vehicle.transform.position;
        }
        else
        {
            Debug.LogError("Vehicle not assigned in TimeChallenge script.");
        }

        if (timerText == null)
        {
            Debug.LogError("Timer Text (TMP_Text) not assigned in TimeChallenge script.");
            return;
        }

        currentTime = startTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                OnTimeUp();
            }
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = "Time left: " + timeText;

        // Log the current time and color for debugging
        Debug.Log($"Current Time: {currentTime}, Timer Color: {timerText.color}");

        if (currentTime <= 10f)
        {
            timerText.color = warningColor;
        }
        else
        {
            timerText.color = normalColor;
        }
    }

    void OnTimeUp()
    {
        gamemanager.instance.GameOver();
    }
}
