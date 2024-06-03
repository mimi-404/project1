using UnityEngine;

public class QUIT : MonoBehaviour
{
    public void QuitGame()
    {
        // If we are running in the editor
#if UNITY_EDITOR
       
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application
        Application.Quit();
#endif
    }
}
