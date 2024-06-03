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
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private float _coinHeightAboveTerrain = -6f; // Small positive height above the terrain for coins
    [SerializeField] private float _fuelHeightAboveTerrain = -6f;
    [SerializeField] private float _coinDistance = 5f; // Distance between each coin spawn
    [SerializeField] private float _fuelDistance = 40f; // Distance between each fuel spawn

    private Vector3 _lastPos;
    private List<GameObject> _spawnedObjects = new List<GameObject>();

    private void Start()
    {
        if (Application.isPlaying)
        {
            GenerateTerrain();
        }
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            GenerateTerrain();
        }
    }

    private void GenerateTerrain()
    {
        // Clear existing spline and spawned objects
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

            // Check if the current position is a multiple of the distanceBetweenCoins
            if (i % _coinDistance == 0 || i % (_coinDistance * 2) == 0 || i % (_coinDistance * 3) == 0)
            {
                Vector3 coinPosition = new Vector3(_lastPos.x, terrainHeight + _coinHeightAboveTerrain);
                SpawnObject(_coinPrefab, coinPosition);
            }

            // Check if the current position is a multiple of the distanceBetweenFuel
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
        if (Application.isPlaying)
        {
            ClearSpawnedObjects();
        }
    }

    private void OnDestroy()
    {
        if (Application.isPlaying)
        {
            ClearSpawnedObjects();
        }
    }
}