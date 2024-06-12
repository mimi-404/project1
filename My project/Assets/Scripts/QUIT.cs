using UnityEngine;

public class QUIT : MonoBehaviour
{

        AudioManager audioManager;
        private void Awake()
        {
                audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }
        public void QuitGame()
        {
                // If we are running in the editor
#if UNITY_EDITOR
       
        UnityEditor.EditorApplication.isPlaying = false;
#else
                audioManager.PlaySFX(audioManager.quit);
                // Quit the application
                Application.Quit();
#endif
        }
}
