using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _smoothness = 1f;
	[SerializeField] private float _rotationSmoothness = .1f;
	[SerializeField] private Vector3 _offset;

	private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
		if (_target == null)
			Destroy(this);
	}

    private void FixedUpdate()
	{
		Vector3 targetPosition = _target.TransformDirection(_offset);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothness);

        Quaternion targetRotation = Quaternion.LookRotation(-transform.position.normalized, _target.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSmoothness);
    }

}
