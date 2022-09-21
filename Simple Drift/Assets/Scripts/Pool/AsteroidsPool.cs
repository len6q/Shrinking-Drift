using System;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsPool : ObjectPool
{    
    [SerializeField] private Asteroid _asteroidToPool;
    [SerializeField, Range(35,100)] private int _amountToPool = 35;    

    private Queue<Asteroid> _pooledAsteroids = new Queue<Asteroid>();

    private void Awake()
    {
        for(int i = 0; i < _amountToPool; i++)
        {
            CreateElement(_asteroidToPool, _pooledAsteroids);
        }
    }

    public Asteroid GetPooledAsteroid(Vector3 position, Quaternion rotation)
    {
        if(TryGetElement(out Asteroid asteroid, _pooledAsteroids))
        {            
            asteroid.transform.position = position;
            asteroid.transform.rotation = rotation;
            asteroid.StartTrailAnimation(true);            
        }
        return asteroid;                
    }
}
