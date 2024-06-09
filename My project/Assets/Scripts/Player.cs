using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public CarDatabase carDB;

    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
          if (!PlayerPrefs.HasKey("selectedOption"))
        {
           selectedOption = 0;
        }
        else
        {
           Load();
        }
        UpdateCar(selectedOption);
    }

 
    private void UpdateCar(int selectedOption)
    {
        Car car = carDB.GetCar(selectedOption);  // Corrected typo here
        artworkSprite.sprite = car.carSprite;
    }
    private void Load()
    {
       selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
