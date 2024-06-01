//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnvironmentSpawner : MonoBehaviour
//{
//    public GameObject coinPrefab;    // Reference to the coin prefab
//    public GameObject fuelPrefab;    // Reference to the fuel prefab
//    public int numberOfCoins = 50;   // Number of coins to spawn
//    public int numberOfFuel = 5;     // Number of fuel items to spawn
//    public Vector2 coinSpawnAreaMin; // Minimum x and y coordinates for coin spawning
//    public Vector2 coinSpawnAreaMax; // Maximum x and y coordinates for coin spawning
//    public Vector2 fuelSpawnAreaMin; // Minimum x and y coordinates for fuel spawning
//    public Vector2 fuelSpawnAreaMax; // Maximum x and y coordinates for fuel spawning

//    void Start()
//    {
//        SpawnItems(coinPrefab, numberOfCoins, coinSpawnAreaMin, coinSpawnAreaMax);
//        SpawnItems(fuelPrefab, numberOfFuel, fuelSpawnAreaMin, fuelSpawnAreaMax);
//    }

//    void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
//    {
//        for (int i = 0; i < count; i++)
//        {
//            float randomX = Random.Range(areaMin.x, areaMax.x);
//            float randomZ = Random.Range(areaMin.y, areaMax.y);
//            Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);
//            Instantiate(prefab, spawnPosition, Quaternion.identity);
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject coinPrefab;    // Reference to the coin prefab
    public GameObject fuelPrefab;    // Reference to the fuel prefab
    public int numberOfCoins = 50;   // Number of coins to spawn
    public int numberOfFuel = 5;     // Number of fuel items to spawn
    public Vector2 coinSpawnAreaMin; // Minimum x and y coordinates for coin spawning
    public Vector2 coinSpawnAreaMax; // Maximum x and y coordinates for coin spawning
    public Vector2 fuelSpawnAreaMin; // Minimum x and y coordinates for fuel spawning
    public Vector2 fuelSpawnAreaMax; // Maximum x and y coordinates for fuel spawning

    void Start()
    {
        SpawnItems(coinPrefab, numberOfCoins, coinSpawnAreaMin, coinSpawnAreaMax);
        SpawnItems(fuelPrefab, numberOfFuel, fuelSpawnAreaMin, fuelSpawnAreaMax);
    }

    void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(areaMin.x, areaMax.x);
            float randomY = Random.Range(areaMin.y, areaMax.y);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Ensure the z position is 0 for 2D
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
