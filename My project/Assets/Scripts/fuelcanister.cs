using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelcanister : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
           
            if (fuelcontroller.instance != null)
            {
                fuelcontroller.instance.FillFuel();
            }
            else
            {
                Debug.LogError("FuelController instance is not set.");
            }

            
            Destroy(gameObject);
        }
    }
}
