using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50f;
    [SerializeField] private float _maxSpeed = 25f;
    [SerializeField] private float _rotateSpeed = 90f;
    [SerializeField] private float _steerAngle = 90f;

    private float _drag = .98f;
    private Vector3 _moveForce;
    private Rigidbody _car;

    private void Awake() => _car = GetComponent<Rigidbody>();

    public void Move(Vector3 direction)
    {
        _moveForce += transform.forward * _moveSpeed * Time.deltaTime;
        _car.MovePosition(_car.position + _moveForce * Time.deltaTime);
   
        Vector3 yRotation = Vector3.up * direction.x * _moveForce.magnitude * _steerAngle * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = _car.rotation * deltaRotation;
        _car.MoveRotation(Quaternion.Slerp(_car.rotation, targetRotation, _rotateSpeed * Time.deltaTime));

        _moveForce = Vector3.ClampMagnitude(_moveForce * _drag, _maxSpeed);
        _moveForce = Vector3.Lerp(_moveForce.normalized, transform.forward, Time.deltaTime) * _moveForce.magnitude;

    }
}
