using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private Canvas mainGameCanvas;

    private bool isPaused = false;

    public Button pauseButton;
    public Button playButton;
    public Sprite pauseSprite;
    public Sprite resumeSprite;
    AudioManager audioManager;
    private void Start()
    {
        // Set the pause button sprite
        if (pauseButton != null && pauseSprite != null)
        {
            pauseButton.image.sprite = pauseSprite;
            pauseButton.gameObject.SetActive(true);
        }
        // Set the play button sprite and hide it initially
        if (playButton != null && resumeSprite != null)
        {
            playButton.image.sprite = resumeSprite;
            playButton.gameObject.SetActive(false); // Initially, play button is hidden
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void GameOver()
    {
        audioManager.StopMusic();
        DisableCanvasUI(mainGameCanvas);
        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        _gameOverCanvas.SetActive(true);

        DisableCanvasUI(mainGameCanvas);
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        audioManager.PlaySFX(audioManager.button2);
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

            canvas.gameObject.SetActive(false); // Hide the canvas
        }
        else
        {
            Debug.LogError("Main Game Canvas not assigned in gamemanager script.");
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            audioManager.PlaySFX(audioManager.buttonClick);
            audioManager.StopMusic();
            Debug.Log("Pausing game: hiding pause button and showing play button");
            // Hide the pause button and show the play button
            pauseButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            audioManager.PlaySFX(audioManager.buttonClick);
            audioManager.PlayMusic();
            Debug.Log("Resuming game: hiding play button and showing pause button");
            // Hide the play button and show the pause button
            pauseButton.gameObject.SetActive(true);
            playButton.gameObject.SetActive(false);
        }
    }
}