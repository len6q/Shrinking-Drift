using UnityEngine;

public class ExplosionsSpawner : MonoBehaviour
{
    [SerializeField] private ExplosionsPool _explosionsPool;    

    private void Awake()
    {
        Asteroid.OnFellGround += SpawnExplosion;
    }

    private void OnDestroy()
    {
        Asteroid.OnFellGround -= SpawnExplosion;
    }

    private void SpawnExplosion(Vector3 pos, Quaternion rot)
    {
        _explosionsPool.GetPooledExplosion(pos, rot);
    }
}
