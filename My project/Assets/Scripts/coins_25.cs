using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins_25 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coincollector.instance.AddCoin_25();
            Destroy(gameObject);
        }
    }
}
