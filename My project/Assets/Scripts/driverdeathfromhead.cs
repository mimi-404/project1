using UnityEngine;

public class DriverDeathFromHead : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            audioManager.PlaySFX(audioManager.carCollide);
            gamemanager.instance.GameOver();
        }
    }
}
