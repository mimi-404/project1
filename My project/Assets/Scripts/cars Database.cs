using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCarCollection", menuName = "Car Collection")]
public class CarCollection : ScriptableObject
{
    public Car[] cars;

    public int CarCount
    {
        get
        {
            return cars.Length;
        }
    }

    public Car GetCar(int index)
    {
        if (index >= 0 && index < cars.Length)
        {
            return cars[index];
        }
        else
        {
            Debug.LogError("Index out of range");
            return null;
        }
    }
}
