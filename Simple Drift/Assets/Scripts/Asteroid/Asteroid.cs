using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;

	private ParticleSystem _trail;
    private bool _onPlace = false;

    private void Start()
    {
        _trail = GetComponent<ParticleSystem>();
        _trail.Play();
    }

    private void Update()
    {
        transform.localScale *= 1f - Planet.ShrinkSpeed * Time.deltaTime;

        if (transform.localScale.x < .5f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!_onPlace && collision.gameObject.TryGetComponent(out Planet planet))
        {
            _onPlace = true;

            Quaternion rotation = Quaternion.LookRotation(transform.position.normalized);
            rotation *= Quaternion.Euler(90f, 0f, 0f);
            Instantiate(_explosion, collision.contacts[0].point, rotation);

            _trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

	}

}
