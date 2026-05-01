using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private int _numPlatformsToSpawn = 100;
    [SerializeField] private GameObject _firstPlatform;
    [SerializeField] private float _maxDistanceFromPreviousPlatform = 3f;
    [SerializeField] private float _minDistanceFromPreviousPlatform = 1.5f;
    [SerializeField] private float _xSpawnRange = 6f;

    private GameObject _lastSpawnedPlatform;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lastSpawnedPlatform = _firstPlatform;
        SpawnPlatforms();

    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.y > _lastSpawnedPlatform.transform.position.y + _maxDistanceFromPreviousPlatform)
        {
            SpawnPlatforms();

        }
        
    }

    private void SpawnPlatforms()
    {
        for(int i = 0; i < _numPlatformsToSpawn; i++)
        {
            float distanceToNextPlatform = UnityEngine.Random.Range(_minDistanceFromPreviousPlatform, _maxDistanceFromPreviousPlatform);
            float xPosition = UnityEngine.Random.Range(-_xSpawnRange, _xSpawnRange);
            Vector2 spawnPosition = new Vector2(xPosition, _lastSpawnedPlatform.transform.position.y + distanceToNextPlatform);
            _lastSpawnedPlatform = Instantiate(_platformPrefab, spawnPosition, Quaternion.identity);

        }
    }
}
