// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Collections;
// public class backtomenu : MonoBehaviour
// {
//     AudioManager audioManager;
//     private void Awake()
//     {
//         audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
//     }

//     public void LoadMainMenu()
//     {
//         audioManager.PlaySFX(audioManager.button2);
//         StartCoroutine(LoadSceneAfterSound());
//     }

//     private IEnumerator LoadSceneAfterSound()
//     {
//         yield return new WaitForSeconds(audioManager.button2.length);
//         SceneManager.LoadScene("main");
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class backtomenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void LoadMainMenu()
    {
        audioManager.PlaySFX(audioManager.button2);
        SceneManager.LoadScene("main");
    }
}

