// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.U2D;

// public class EnvironmentGenerator : MonoBehaviour
// {
//     [SerializeField] private SpriteShapeController _spriteShapeController;

//     [SerializeField, Range(3f, 600f)] private int _levelLength = 50;
//     [SerializeField, Range(1f, 50f)] private float _xMultiplier = 2f;
//     [SerializeField, Range(1f, 50f)] private float _yMultiplier = 2f;
//     [SerializeField, Range(0f, 1f)] private float _curveSmoothness = 0.5f;
//     [SerializeField] private float _noiseStep = 0.5f;
//     [SerializeField] private float _bottom = 10f;

//     [SerializeField] private GameObject _fuelPrefab;
//     [SerializeField] private GameObject[] _coinPrefabs; // Array of different coin prefabs
//     [SerializeField] private float _coinHeightAboveTerrain = -6f; // Small positive height above the terrain for coins
//     [SerializeField] private float _fuelHeightAboveTerrain = -6f;
//     [SerializeField] private float _coinDistance = 5f; // Distance between each coin spawn
//     [SerializeField] private float _fuelDistance = 20f; // Decreased fuel spawn distance
//     [SerializeField] private float _coinSpacing = 2f; // Horizontal spacing between coins in a group

//     private Vector3 _lastPos;
//     private List<GameObject> _spawnedObjects = new List<GameObject>();

//     private void Start()
//     {
//         if (Application.isPlaying)
//         {
//             GenerateTerrain();
//         }
//     }

//     private void OnValidate()
//     {
//         if (Application.isPlaying)
//         {
//             GenerateTerrain();
//         }
//     }

//     private void GenerateTerrain()
//     {
//         // Clear existing spline and spawned objects
//         ClearSpawnedObjects();
//         _spriteShapeController.spline.Clear();

//         float seed = Random.Range(0f, 400f);

//         for (int i = 0; i < _levelLength; i++)
//         {
//             float terrainHeight = Mathf.PerlinNoise(seed, i * _noiseStep) * _yMultiplier;
//             _lastPos = new Vector3(i * _xMultiplier, terrainHeight);
//             _spriteShapeController.spline.InsertPointAt(i, _lastPos);

//             if (i != 0 && i != _levelLength - 1)
//             {
//                 _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
//                 _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
//                 _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
//             }

//             // Check if the current position is a multiple of the distanceBetweenCoins
//             if (i % _coinDistance == 0 || i % (_coinDistance * 2) == 0 || i % (_coinDistance * 3) == 0)
//             {
//                 Vector3 coinGroupPosition = new Vector3(_lastPos.x, terrainHeight + _coinHeightAboveTerrain);
//                 SpawnCoinGroup(coinGroupPosition);
//             }

//             // Check if the current position is a multiple of the distanceBetweenFuel
//             if (i % _fuelDistance == 0)
//             {
//                 Vector3 fuelPosition = new Vector3(_lastPos.x, terrainHeight + _fuelHeightAboveTerrain);
//                 SpawnObject(_fuelPrefab, fuelPosition);
//             }
//         }

//         _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, -_bottom));
//         _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(0, -_bottom));

//         _spriteShapeController.RefreshSpriteShape();
//     }

//     private void SpawnCoinGroup(Vector3 position)
//     {
//         if (_coinPrefabs != null && _coinPrefabs.Length >= 4)
//         {
//             List<int> usedIndices = new List<int>();

//             for (int i = 0; i < 4; i++)
//             {
//                 int randomIndex;
//                 do
//                 {
//                     randomIndex = Random.Range(0, _coinPrefabs.Length);
//                 } while (usedIndices.Contains(randomIndex));

//                 usedIndices.Add(randomIndex);

//                 Vector3 coinPosition = position + new Vector3(i * _coinSpacing, 0, 0); // Adjust x-position for each coin
//                 SpawnObject(_coinPrefabs[randomIndex], coinPosition);
//             }
//         }
//     }

//     private void SpawnObject(GameObject prefab, Vector3 position)
//     {
//         if (prefab != null)
//         {
//             GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);
//             _spawnedObjects.Add(obj);
//         }
//     }

//     private void ClearSpawnedObjects()
//     {
//         foreach (var obj in _spawnedObjects)
//         {
//             if (obj != null) Destroy(obj);
//         }
//         _spawnedObjects.Clear();
//     }

//     private void OnDisable()
//     {
//         if (Application.isPlaying)
//         {
//             ClearSpawnedObjects();
//         }
//     }

//     private void OnDestroy()
//     {
//         if (Application.isPlaying)
//         {
//             ClearSpawnedObjects();
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _spriteShapeController;

    [SerializeField, Range(3f, 600f)] private int _levelLength = 50;
    [SerializeField, Range(1f, 50f)] private float _xMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float _yMultiplier = 2f;
    [SerializeField, Range(0f, 1f)] private float _curveSmoothness = 0.5f;
    [SerializeField] private float _noiseStep = 0.5f;
    [SerializeField] private float _bottom = 10f;

    [SerializeField] private GameObject _fuelPrefab;
    [SerializeField] private GameObject[] _coinPrefabs;
    [SerializeField] private float _coinHeightAboveTerrain = -6f;
    [SerializeField] private float _fuelHeightAboveTerrain = -6f;
    [SerializeField] private float _coinDistance = 5f;
    [SerializeField] private float _fuelDistance = 20f;
    [SerializeField] private float _coinSpacing = 2f;

    private Vector3 _lastPos;
    private List<GameObject> _spawnedObjects = new List<GameObject>();

    private void Start()
    {
        if (_spriteShapeController == null)
        {
            Debug.LogError("SpriteShapeController is not assigned!");
            return;
        }

        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        ClearSpawnedObjects();
        _spriteShapeController.spline.Clear();

        float seed = Random.Range(0f, 400f);

        for (int i = 0; i < _levelLength; i++)
        {
            float terrainHeight = Mathf.PerlinNoise(seed, i * _noiseStep) * _yMultiplier;
            _lastPos = new Vector3(i * _xMultiplier, terrainHeight);
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i != 0 && i != _levelLength - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }

            if (i % _coinDistance == 0 || i % (_coinDistance * 2) == 0 || i % (_coinDistance * 3) == 0)
            {
                Vector3 coinGroupPosition = new Vector3(_lastPos.x, terrainHeight + _coinHeightAboveTerrain);
                SpawnCoinGroup(coinGroupPosition);
            }

            if (i % _fuelDistance == 0)
            {
                Vector3 fuelPosition = new Vector3(_lastPos.x, terrainHeight + _fuelHeightAboveTerrain);
                SpawnObject(_fuelPrefab, fuelPosition);
            }
        }

        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, -_bottom));
        _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(0, -_bottom));

        _spriteShapeController.RefreshSpriteShape();
    }

    private void SpawnCoinGroup(Vector3 position)
    {
        if (_coinPrefabs != null && _coinPrefabs.Length >= 4)
        {
            List<int> usedIndices = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, _coinPrefabs.Length);
                } while (usedIndices.Contains(randomIndex));

                usedIndices.Add(randomIndex);

                Vector3 coinPosition = position + new Vector3(i * _coinSpacing, 0, 0);
                SpawnObject(_coinPrefabs[randomIndex], coinPosition);
            }
        }
    }

    private void SpawnObject(GameObject prefab, Vector3 position)
    {
        if (prefab != null)
        {
            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);
            _spawnedObjects.Add(obj);
        }
    }

    private void ClearSpawnedObjects()
    {
        foreach (var obj in _spawnedObjects)
        {
            if (obj != null) Destroy(obj);
        }
        _spawnedObjects.Clear();
    }

    private void OnDisable()
    {
        ClearSpawnedObjects();
    }

    private void OnDestroy()
    {
        ClearSpawnedObjects();
    }
}
