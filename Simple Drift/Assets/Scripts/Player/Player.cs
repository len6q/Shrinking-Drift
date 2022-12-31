using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private bool _inMenu;   

    public event Action OnDead;    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Asteroid asteroid) && _inMenu == false)
        {
            Quaternion rotation = Quaternion.LookRotation(transform.position.normalized);
            rotation *= Quaternion.Euler(90f, 0f, 0f);
            Instantiate(_explosion, collision.contacts[0].point, rotation);

            OnDead?.Invoke();

            Destroy(gameObject);         
        }
    }
}
