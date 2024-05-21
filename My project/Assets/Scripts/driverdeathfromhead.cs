using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driverdeathfromhead : MonoBehaviour
{
   private void OnCollisiondeath(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            gamemanager.instance.GameOver();
        }
    }
}
