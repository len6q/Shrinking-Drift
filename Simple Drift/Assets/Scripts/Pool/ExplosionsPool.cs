using System.Collections.Generic;
using UnityEngine;

public class ExplosionsPool : ObjectPool
{
    [SerializeField] private Explosion _explosionToPool;
    [SerializeField, Range(3, 6)] private int _amountToPool = 4;    

    private Queue<Explosion> _pooledExplosion = new Queue<Explosion>();

    private void Awake()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            CreateElement(_explosionToPool, _pooledExplosion);
        }
    }

    public Explosion GetPooledExplosion(Vector3 position, Quaternion rotation)
    {
        if (TryGetElement(out Explosion explosion, _pooledExplosion))
        {
            explosion.transform.position = position;
            explosion.transform.rotation = rotation;            
        }
        return explosion;
    }
}
