using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public CarDatabase carDB;
   public SpriteRenderer artworkSprite;
   private int selectedOption = 0;

   void Start()
   {
      Debug.Log("Start method called");

      if (!PlayerPrefs.HasKey("selectedOption"))
      {
         selectedOption = 0;
         Debug.Log("No selectedOption key in PlayerPrefs, defaulting to 0");
      }
      else
      {
         Load();
         Debug.Log("Loaded selectedOption: " + selectedOption);
      }

      UpdateCar(selectedOption);
   }

   private void UpdateCar(int selectedOption)
   {
      Debug.Log("UpdateCar method called with selectedOption: " + selectedOption);

      if (carDB == null)
      {
         Debug.LogError("carDB is not assigned in the Inspector.");
         return;
      }

      Car car = carDB.GetCar(selectedOption);
      if (car == null)
      {
         Debug.LogError("No car found for selectedOption: " + selectedOption);
         return;
      }

      if (car.carSprite == null)
      {
         Debug.LogError("Car sprite is null for selectedOption: " + selectedOption);
         return;
      }

      if (artworkSprite == null)
      {
         Debug.LogError("artworkSprite is not assigned in the Inspector.");
         return;
      }

      artworkSprite.sprite = car.carSprite;
      Debug.Log("Updated artworkSprite with car sprite for selectedOption: " + selectedOption);
   }

   private void Load()
   {
      selectedOption = PlayerPrefs.GetInt("selectedOption");
      Debug.Log("Loaded selectedOption from PlayerPrefs: " + selectedOption);
   }
}
