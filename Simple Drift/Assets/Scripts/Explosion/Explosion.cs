using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void Update()
    {
        if(_particle.isPlaying == false)
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {        
        gameObject.SetActive(false);
    }
}
