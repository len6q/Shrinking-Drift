using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private ParticleSystem _trail;

    private void Update()
    {
        transform.localScale *= 1f - Planet.ShrinkSpeed * Time.deltaTime;

        if (transform.localScale.x < .5f)
        {
            ReturnToPool();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Planet planet))
        {
            Quaternion rotation = Quaternion.LookRotation(transform.position.normalized);
            rotation *= Quaternion.Euler(90f, 0f, 0f);
            Instantiate(_explosion, collision.contacts[0].point, rotation);

            StartTrailAnimation(false);       
        }
	}

    public void StartTrailAnimation(bool animationState)
    {     
        if(animationState)
        {
            _trail.Play();
        }
        else
        {
            _trail.Stop();
        }        
    }

    private void ReturnToPool()
    {
        transform.localScale = Vector3.one;        
        gameObject.SetActive(false);
    }
}
