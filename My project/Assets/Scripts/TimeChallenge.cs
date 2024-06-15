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
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

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
    bool isTimeAudioPlaying = false;

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = "Time left: " + timeText;

        if (currentTime <= 10f && !isTimeAudioPlaying)
        {
            audioManager.PlaySFX(audioManager.time);
            isTimeAudioPlaying = true; // Mark the "time" audio as playing
            timerText.color = warningColor;
        }
        else if (currentTime > 10f)
        {
            // Reset the flag if the current time is adjusted to be more than 10 seconds again
            isTimeAudioPlaying = false;
            timerText.color = normalColor;
        }
    }

    void OnTimeUp()
    {
        // No need to stop the "time" audio explicitly
        audioManager.StopMusic();
        audioManager.PlaySFX(audioManager.gameOver);
        gamemanager.instance.GameOver();
        isTimeAudioPlaying = false; // Reset the flag when the game is over
    }

}
