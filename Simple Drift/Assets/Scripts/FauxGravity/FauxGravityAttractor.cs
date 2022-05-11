using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class FauxGravityAttractor : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _rotateSpeed = 50f;

    private SphereCollider _planet;

    private void Awake() => _planet = GetComponent<SphereCollider>();

    public void Attract(Rigidbody body)
    {    
        Vector3 gravityUp = (body.position - transform.position).normalized;
        body.AddForce(gravityUp * _gravity);

        RotateBody(body, gravityUp);
    }

    public void PlaceOnSurface(Rigidbody body)
    { 
        Vector3 gravityUp = (body.position - transform.position).normalized;
        body.MovePosition(gravityUp * transform.localScale.x * _planet.radius);

        RotateBody(body, gravityUp);
    }

    private void RotateBody(Rigidbody body, Vector3 gravityUp)
    {      
        Quaternion targetRotation = Quaternion.FromToRotation(body.transform.up, gravityUp) * body.rotation;
        body.MoveRotation(Quaternion.Lerp(body.rotation, targetRotation, _rotateSpeed * Time.deltaTime));
    }
}
