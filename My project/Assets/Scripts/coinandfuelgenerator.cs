
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinandfuelgenerator : MonoBehaviour
{
    public GameObject coinPrefab;    // Reference to the coin prefab
    public GameObject fuelPrefab;    // Reference to the fuel prefab
    public int numberOfCoins = 50;   // Number of coins to spawn
    public int numberOfFuel = 5;     // Number of fuel items to spawn
    public Vector2 coinSpawnAreaMin = new Vector2(-8.89f, -10f); // Minimum x and y coordinates for coin spawning
    public Vector2 coinSpawnAreaMax = new Vector2(8.89f, 10f);   // Maximum x and y coordinates for coin spawning
    public Vector2 fuelSpawnAreaMin = new Vector2(-8.89f, -10f); // Minimum x and y coordinates for fuel spawning
    public Vector2 fuelSpawnAreaMax = new Vector2(8.89f, 10f);   // Maximum x and y coordinates for fuel spawning

    void Start()
    {
        SpawnItems(coinPrefab, numberOfCoins, coinSpawnAreaMin, coinSpawnAreaMax);
        SpawnItems(fuelPrefab, numberOfFuel, fuelSpawnAreaMin, fuelSpawnAreaMax);
    }
    void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
    {
        // Debug.Log($"Spawning {count} items of {prefab.name}.");

        // Define the range of y-axis movement for coins
        float minY = areaMin.y;
        float maxY = minY + 2.0f; // Limit the maximum height coins can reach

        for (int i = 0; i < count; i++)
        {
            // Randomize x-axis position for spreading out along the x-axis
            float randomX = Random.Range(areaMin.x, areaMax.x);

            // Randomize y-axis position within the defined range
            float randomY = Random.Range(minY, maxY);

            // Update minY and maxY to move coins upwards
            minY += 0.5f; // Adjust the increment as needed
            maxY = Mathf.Min(maxY + 0.5f, areaMax.y); // Ensure maxY stays within the spawn area

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Ensure z-axis remains at 0 for 2D
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            //Debug.Log($"Spawned {prefab.name} at {spawnPosition}");
        }
    }
}

