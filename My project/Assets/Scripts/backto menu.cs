using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenu : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void LoadMainMenu()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        SceneManager.LoadScene("main");
    }
}
