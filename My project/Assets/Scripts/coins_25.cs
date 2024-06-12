using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins_25 : MonoBehaviour
{
    //audioManager.PlaySFX(audioManager.coinCollect);
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.coinCollect);
            coincollector.instance.AddCoin_25();
            Destroy(gameObject);
        }
    }
}
