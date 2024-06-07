using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Fixed typo here

public class CarManager : MonoBehaviour
{
    public CarDatabase carDB;

    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCar(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= carDB.CarCount)
        {
            selectedOption = 0;
        }
        UpdateCar(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = carDB.CarCount - 1;
        }
        UpdateCar(selectedOption);
    }

    private void UpdateCar(int selectedOption)
    {
        Car car = carDB.GetCar(selectedOption);  // Corrected typo here
        artworkSprite.sprite = car.carSprite;
    }
}
