using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private Canvas mainGameCanvas;
    [SerializeField] private GameObject imageCanvas;
    private bool isPaused = false;

    public Button pauseButton;
    public Sprite pauseSprite;
    public Sprite resumeSprite;

    private void Start()
    {
        if (pauseButton != null && pauseSprite != null)
        {
            pauseButton.image.sprite = pauseSprite;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }



    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        if (imageCanvas != null)
        {
            imageCanvas.SetActive(true); // Enable the Image Canvas when the game is over
        }
        else
        {
            Debug.LogError("Image Canvas not assigned in gamemanager script.");
        }
        DisableCanvasUI(mainGameCanvas);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DisableCanvasUI(Canvas canvas)
    {
        if (canvas != null)
        {
            Button[] buttons = canvas.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }

            Selectable[] selectables = canvas.GetComponentsInChildren<Selectable>();
            foreach (Selectable selectable in selectables)
            {
                selectable.interactable = false;
            }
        }
        else
        {
            Debug.LogError("Main Game Canvas not assigned in gamemanager script.");
        }
    }


    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;

            if (pauseButton != null && resumeSprite != null)
            {
                pauseButton.image.sprite = resumeSprite;
            }
        }
        else
        {
            Time.timeScale = 1f;

            if (pauseButton != null && pauseSprite != null)
            {
                pauseButton.image.sprite = pauseSprite;
            }
        }
    }
}