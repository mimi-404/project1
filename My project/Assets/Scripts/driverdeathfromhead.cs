//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class driverdeathfromhead : MonoBehaviour
//{
//   private void OnCollisiondeath(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("ground"))
//        {
//            gamemanager.instance.GameOver();
//        }
//    }
//}
using UnityEngine;

public class driverdeathfromhead : MonoBehaviour
{
    private gamemanager gameOverManager;

    private void Start()
    {
        // Find the GameOverManager in the scene (ensure it exists)
        gameOverManager = FindObjectOfType<gamemanager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with any object
        if (collision.collider != null)
        {
            // Trigger the game over logic
            gameOverManager.GameOver();
        }
    }
}
