// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.SceneManagement;
// // using UnityEngine.UI;

// // public class gamemanager : MonoBehaviour
// // {
// //     public static gamemanager instance;

// //     [SerializeField] private GameObject _gameOverCanvas;
// //     [SerializeField] private Canvas mainGameCanvas;
// //     [SerializeField] private GameObject imageCanvas; // Add this line to reference the Image Canvas

// //     private void Awake()
// //     {
// //         if (instance == null)
// //         {
// //             instance = this;
// //         }

// //         Time.timeScale = 1f;
// //     }

// //     public void GameOver()
// //     {
// //         _gameOverCanvas.SetActive(true);
// //         if (imageCanvas != null)
// //         {
// //             imageCanvas.SetActive(true); // Enable the Image Canvas when the game is over
// //         }
// //         else
// //         {
// //             Debug.LogError("Image Canvas not assigned in gamemanager script.");
// //         }
// //         DisableCanvasUI(mainGameCanvas);
// //         Time.timeScale = 0f;
// //     }

// //     public void RestartGame()
// //     {
// //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
// //     }

// //     private void DisableCanvasUI(Canvas canvas)
// //     {
// //         if (canvas != null)
// //         {
// //             Button[] buttons = canvas.GetComponentsInChildren<Button>();
// //             foreach (Button button in buttons)
// //             {
// //                 button.interactable = false;
// //             }

// //             Selectable[] selectables = canvas.GetComponentsInChildren<Selectable>();
// //             foreach (Selectable selectable in selectables)
// //             {
// //                 selectable.interactable = false;
// //             }
// //         }
// //         else
// //         {
// //             Debug.LogError("Main Game Canvas not assigned in gamemanager script.");
// //         }
// //     }
// // }
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class gamemanager : MonoBehaviour
// {
//     public static gamemanager instance;
//     private Control controlScript;


//     void Start()
//     {
//         controlScript = Camera.main.GetComponent<Control>(); // Get Control script attached to main camera
//         // Other initialization...
//     }

//     [SerializeField] private GameObject _gameOverCanvas;
//     [SerializeField] private Canvas mainGameCanvas;
//     [SerializeField] private GameObject imageCanvas; // Add this line to reference the Image Canvas

//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//         }

//         Time.timeScale = 1f;
//     }

//     public void GameOver()
//     {

//         // Trigger the zoom-in effect on the vehicle before enabling the canvases
//         if (controlScript != null)
//         {
//             controlScript.StartZoomEffect();
//         }

//         _gameOverCanvas.SetActive(true);
//         if (imageCanvas != null)
//         {
//             imageCanvas.SetActive(true); // Enable the Image Canvas when the game is over
//         }
//         else
//         {
//             Debug.LogError("Image Canvas not assigned in gamemanager script.");
//         }
//         DisableCanvasUI(mainGameCanvas);
//         Time.timeScale = 0f;
//     }

//     public void RestartGame()
//     {

//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

//     private void DisableCanvasUI(Canvas canvas)
//     {
//         if (canvas != null)
//         {
//             Button[] buttons = canvas.GetComponentsInChildren<Button>();
//             foreach (Button button in buttons)
//             {
//                 button.interactable = false;
//             }

//             Selectable[] selectables = canvas.GetComponentsInChildren<Selectable>();
//             foreach (Selectable selectable in selectables)
//             {
//                 selectable.interactable = false;
//             }
//         }
//         else
//         {
//             Debug.LogError("Main Game Canvas not assigned in gamemanager script.");
//         }
//     }
// }
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    private Control controlScript;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private Canvas mainGameCanvas;
    [SerializeField] private GameObject imageCanvas; // Add this line to reference the Image Canvas

    void Start()
    {
        controlScript = Camera.main.GetComponent<Control>(); // Get Control script attached to main camera
        // Other initialization...
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
        // Trigger the zoom-in effect on the vehicle before enabling the canvases
        if (controlScript != null)
        {
            controlScript.StartZoomEffect();
        }

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
}
