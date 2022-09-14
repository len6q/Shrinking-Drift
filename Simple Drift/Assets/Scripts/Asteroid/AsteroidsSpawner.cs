using UnityEngine;
using System.Collections;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private AsteroidsPool _asteroidsPool;
    [SerializeField] private Asteroid _spawnedPrefab;
    [SerializeField] private float _waitSecondsBeforeSpawn = 5f;
    [SerializeField] private float _distanceSpawn = 60f;

    private void Start()
    {
        _asteroidsPool.CreatePool();

        StartCoroutine(SpawnAsteroid());
    }

    private IEnumerator SpawnAsteroid()
    {
        while (true)
        {      
            Vector3 position = Random.onUnitSphere * _distanceSpawn;            
            _asteroidsPool.GetPooledAsteroid(position, Quaternion.identity);            

            yield return new WaitForSeconds(_waitSecondsBeforeSpawn);
        }        
    }
}
