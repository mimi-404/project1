using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelCanister : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fuelcontroller.instance.FillFuel();
            Destroy(gameObject);
        }
    }
    

}
