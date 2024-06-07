// using UnityEngine;
// using TMPro;

// public class TimeChallenge : MonoBehaviour
// {
//     public float startTime = 60f;
//     private float currentTime;
//     public TMP_Text timerText;
//     public GameObject vehicle;
//     private Vector3 startPosition;
//     public Color normalColor = Color.white;
//     public Color warningColor = Color.red;

//     void Start()
//     {
//         if (vehicle != null)
//         {
//             startPosition = vehicle.transform.position;
//         }
//         else
//         {
//             Debug.LogError("Vehicle not assigned in TimeChallenge script.");
//         }

//         currentTime = startTime;
//         UpdateTimerDisplay();
//     }

//     void Update()
//     {
//         if (currentTime > 0)
//         {
//             currentTime -= Time.deltaTime;
//             UpdateTimerDisplay();

//             if (currentTime <= 0)
//             {
//                 currentTime = 0;
//                 OnTimeUp();
//             }
//         }
//     }

//     void UpdateTimerDisplay()
//     {
//         int minutes = Mathf.FloorToInt(currentTime / 60F);
//         int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
//         string timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
//         timerText.text = "Time left: " + timeText;

//         if (currentTime <= 10)
//         {
//             timerText.color = warningColor;
//         }
//         else
//         {
//             timerText.color = normalColor;
//         }
//     }

//     void OnTimeUp()
//     {
//         gamemanager.instance.GameOver();
//     }
// }
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
            Debug.Log("Vehicle start position: " + startPosition);
        }
        else
        {
            Debug.LogError("Vehicle not assigned in TimeChallenge script.");
        }

        currentTime = startTime;
        UpdateTimerDisplay();
        Debug.Log("Start time: " + startTime);
    }

    void Update()
    {

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();

            if (currentTime <= 0)
            {
                currentTime = 0;
                OnTimeUp();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = "Time left: " + timeText;

        if (currentTime <= 10)
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
