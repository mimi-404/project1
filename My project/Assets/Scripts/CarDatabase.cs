using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CarDatabase : ScriptableObject
{
    public Car[] car;

    public int CarCount
    {
        get
        {
            return car.Length;
        }
    }
    public Car GetCar(int index)
    {
        return car[index];
    }
}