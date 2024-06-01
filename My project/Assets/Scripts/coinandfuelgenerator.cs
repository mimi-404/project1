
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
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
        Debug.Log($"Spawning {count} items of {prefab.name}.");

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
            Debug.Log($"Spawned {prefab.name} at {spawnPosition}");
        }
    }

    //void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
    //{
    //    Debug.Log($"Spawning {count} items of {prefab.name}.");

    //    for (int i = 0; i < count; i++)
    //    {
    //        float randomX = Random.Range(areaMin.x, areaMax.x);
    //        float randomY = Random.Range(areaMin.y, areaMax.y);
    //        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
    //        Instantiate(prefab, spawnPosition, Quaternion.identity);
    //        Debug.Log($"Spawned {prefab.name} at {spawnPosition}");
    //    }
    //}


    //    void Start()
    //    {
    //        Debug.Log("EnvironmentSpawner Start method called."); // Debug log to confirm Start is called
    //        SpawnItems(coinPrefab, numberOfCoins, coinSpawnAreaMin, coinSpawnAreaMax);
    //        SpawnItems(fuelPrefab, numberOfFuel, fuelSpawnAreaMin, fuelSpawnAreaMax);
    //    }

    //    void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
    //    {
    //        Debug.Log($"Spawning {count} items of {prefab.name}.");

    //        // List to store already spawned positions
    //        List<Vector3> spawnedPositions = new List<Vector3>();

    //        for (int i = 0; i < count; i++)
    //        {
    //            bool positionFound = false;
    //            int maxAttempts = 10; // Maximum attempts to find a valid position
    //            int attempts = 0;

    //            while (!positionFound && attempts < maxAttempts)
    //            {
    //                // Generate a random position within the spawn area
    //                float randomX = Random.Range(areaMin.x, areaMax.x);
    //                float randomY = Random.Range(areaMin.y, areaMax.y);
    //                Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

    //                // Check if the spawn position overlaps with existing positions
    //                bool overlap = false;
    //                foreach (Vector3 pos in spawnedPositions)
    //                {
    //                    if (Vector3.Distance(spawnPosition, pos) < 1.0f) // Adjust the distance threshold as needed
    //                    {
    //                        overlap = true;
    //                        break;
    //                    }
    //                }

    //                // If no overlap, spawn the item at this position
    //                if (!overlap)
    //                {
    //                    Instantiate(prefab, spawnPosition, Quaternion.identity);
    //                    Debug.Log($"Spawned {prefab.name} at {spawnPosition}");
    //                    spawnedPositions.Add(spawnPosition);
    //                    positionFound = true;
    //                }

    //                attempts++;
    //            }

    //            if (!positionFound)
    //            {
    //                Debug.LogWarning($"Could not find a suitable position for {prefab.name} after {maxAttempts} attempts.");
    //            }
    //        }
    //    }

    //    //void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
    //    //{
    //    //    Debug.Log($"Spawning {count} items of {prefab.name}.");

    //    //    // Calculate the size of each grid cell
    //    //    float cellSizeX = (areaMax.x - areaMin.x) / Mathf.Sqrt(count);
    //    //    float cellSizeY = (areaMax.y - areaMin.y) / Mathf.Sqrt(count);

    //    //    // Iterate over the grid cells and spawn items
    //    //    for (float x = areaMin.x + cellSizeX / 2; x < areaMax.x; x += cellSizeX)
    //    //    {
    //    //        for (float y = areaMin.y + cellSizeY / 2; y < areaMax.y; y += cellSizeY)
    //    //        {
    //    //            Vector3 spawnPosition = new Vector3(x, y, 0);
    //    //            Instantiate(prefab, spawnPosition, Quaternion.identity);
    //    //            Debug.Log($"Spawned {prefab.name} at {spawnPosition}");
    //    //        }
    //    //    }
    //    //}

    //    //void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
    //    //{
    //    //    Debug.Log($"Spawning {count} items of {prefab.name}."); // Debug log to confirm SpawnItems is called
    //    //    for (int i = 0; i < count; i++)
    //    //    {
    //    //        float randomX = Random.Range(areaMin.x, areaMax.x);
    //    //        float randomY = Random.Range(areaMin.y, areaMax.y);
    //    //        Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Ensure the z position is 0 for 2D
    //    //        Instantiate(prefab, spawnPosition, Quaternion.identity);
    //    //        Debug.Log($"Spawned {prefab.name} at {spawnPosition}"); // Debug log to see where items are spawning
    //    //    }
    //    //}
    //    //void SpawnItems(GameObject prefab, int count, Vector2 areaMin, Vector2 areaMax)
    //    //{
    //    //    Debug.Log($"Spawning {count} items of {prefab.name}.");
    //    //    for (int i = 0; i < count; i++)
    //    //    {
    //    //        float randomX = Random.Range(areaMin.x, areaMax.x);
    //    //        float randomY = Random.Range(areaMin.y, areaMax.y);
    //    //        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

    //    //        // Ensure that the spawn position is not too close to existing spawned items
    //    //        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 1f); // Adjust the radius as needed
    //    //        if (colliders.Length == 0)
    //    //        {
    //    //            Instantiate(prefab, spawnPosition, Quaternion.identity);
    //    //            Debug.Log($"Spawned {prefab.name} at {spawnPosition}");
    //    //        }
    //    //        else
    //    //        {
    //    //            i--; // Try again to spawn the item at a different position
    //    //        }
    //    //    }
    //    //}
}

