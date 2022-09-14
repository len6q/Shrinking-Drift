using System.Collections.Generic;
using UnityEngine;

public class AsteroidsPool : MonoBehaviour
{    
    [SerializeField] private Asteroid _asteroidToPool;
    [SerializeField, Range(30,100)] private int _amountToPool = 35;
    [SerializeField] private Transform _garbageCollector;

    private List<Asteroid> _pooledAsteroids;

    public void CreatePool()
    {
        _pooledAsteroids = new List<Asteroid>(_amountToPool);

        for(int i = 0; i < _amountToPool; i++)
        {
            CreateElement();
        }
    }

    private Asteroid CreateElement(bool isActiveByDefault = false)
    {
        Asteroid asteroid = Instantiate(_asteroidToPool, _garbageCollector);        
        asteroid.gameObject.SetActive(isActiveByDefault);
        _pooledAsteroids.Add(asteroid);
        return asteroid;
    }

    private bool TryGetElement(out Asteroid asteroid)
    {
        foreach (var item in _pooledAsteroids)
        {
            if (item.gameObject.activeInHierarchy == false)
            {
                asteroid = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }
        asteroid = null;
        return false;
    }

    public Asteroid GetPooledAsteroid(Vector3 position, Quaternion rotation)
    {
        var asteroid = GetPooledAsteroid();
        asteroid.transform.position = position;
        asteroid.transform.rotation = rotation;
        asteroid.StartTrailAnimation(true);
        return asteroid;
    }

    private Asteroid GetPooledAsteroid()
    {
        if(TryGetElement(out var asteroid))
        {
            return asteroid;
        }
                
        return CreateElement(true);
    }
}
