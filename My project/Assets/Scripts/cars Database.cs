using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[createAssestMenu]
public class NewBehaviourScript : SriptableObject
 {
    public Car[] car;

    public int CarCount
    {
        get{
            return car.Length;
        }
    }
    public Car GetCar(int index){
        return character[index];
    }
 }

