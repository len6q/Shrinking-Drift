using UnityEngine;
using System;

public class Asteroid : MonoBehaviour
{   
    [SerializeField] private ParticleSystem _trail;

    public static event Action<Vector3, Quaternion> OnFellGround;

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
            StartTrailAnimation(false);
            
            Quaternion rotation = Quaternion.LookRotation(transform.position.normalized);
            rotation *= Quaternion.Euler(90f, 0f, 0f);
            OnFellGround?.Invoke(collision.contacts[0].point, rotation);                           
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
