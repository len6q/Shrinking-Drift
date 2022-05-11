using UnityEngine;
using System.Collections;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid _spawnedPrefab;
    [SerializeField] private float _waitSecondsBeforeSpawn = 5f;
    [SerializeField] private float _distanceSpawn = 60f;
    [SerializeField] private Transform _garbageCollector;

    private void Start() => StartCoroutine(SpawnAsteroid());

    private IEnumerator SpawnAsteroid()
    {
        while (true)
        {      
            Vector3 position = Random.onUnitSphere * _distanceSpawn;
            Asteroid asteroid = Instantiate(_spawnedPrefab, position, Quaternion.identity);
            asteroid.transform.parent = _garbageCollector;

            yield return new WaitForSeconds(_waitSecondsBeforeSpawn);
        }
        
    }

}
