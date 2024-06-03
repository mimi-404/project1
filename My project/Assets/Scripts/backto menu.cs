using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("main");
    }
}
