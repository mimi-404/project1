using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
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
    [SerializeField, Range(0f, 1f)] private float _fuelSpawnChance = 0.01f;
    [SerializeField, Range(0f, 1f)] private float _coinSpawnChance = 0.1f;
    [SerializeField] private float _coinHeightAboveTerrain = -7f; // Small positive height above the terrain for coins
    [SerializeField] private float _fuelHeightAboveTerrain = -7f; // Small positive height above the terrain for fuel

    private Vector3 _lastPos;
    private List<GameObject> _spawnedObjects = new List<GameObject>();

    private void Start()
    {
        GenerateTerrain();
    }

    private void OnValidate()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        // Schedule object cleanup
        StartCoroutine(ClearSpawnedObjects());

        // Clear existing spline
        _spriteShapeController.spline.Clear();

        float seed = Random.Range(0f, 400f);

        for (int i = 0; i < _levelLength; i++)
        {
            _lastPos = new Vector3(i * _xMultiplier, Mathf.PerlinNoise(seed, i * _noiseStep) * _yMultiplier);
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i != 0 && i != _levelLength - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }

            // Spawn fuel and coin
            TrySpawnObject(_fuelPrefab, _fuelSpawnChance, _lastPos + Vector3.up * _fuelHeightAboveTerrain);
            TrySpawnObject(_coinPrefab, _coinSpawnChance, _lastPos + Vector3.up * _coinHeightAboveTerrain);
        }

        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, -_bottom));
        _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(0, -_bottom));

        _spriteShapeController.RefreshSpriteShape();
    }

    private void TrySpawnObject(GameObject prefab, float spawnChance, Vector3 position)
    {
        if (Random.value < spawnChance && prefab != null)
        {
            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);
            _spawnedObjects.Add(obj);
            Debug.Log($"Spawned {prefab.name} at {position}");
        }
    }

    private IEnumerator ClearSpawnedObjects()
    {
        foreach (var obj in _spawnedObjects)
        {
            if (obj != null) Destroy(obj);
        }
        _spawnedObjects.Clear();
        yield return null; // Wait until the next frame to continue
    }
}
