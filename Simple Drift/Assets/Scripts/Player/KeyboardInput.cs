using UnityEngine;

[RequireComponent(typeof(Movement))]
public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private bool _onMenu;
    [SerializeField] private Joystick _joystick;

    private Movement _movement;    
    private float _horizontal;

    private static float _velocity = 0f;
    private float _minimumInput = -1f;
    private float _maximumInput = 1f;
    
    private void Awake() => _movement = GetComponent<Movement>();

    private void Update()
    {        
        if (!_onMenu)
            _horizontal = _joystick.Horizontal;
        else
            CyclicMovement();
    }

    private void FixedUpdate() => _movement.Move(new Vector3(_horizontal, 0, 0));

    private void CyclicMovement()
    {        
        _horizontal = Mathf.Lerp(_minimumInput, _maximumInput, _velocity);
        _velocity += .5f * Time.deltaTime;

        if (_velocity > 1f)
        {
            float temp = _minimumInput;
            _minimumInput = _maximumInput;
            _maximumInput = temp;

            _velocity = 0f;
        }
    }

}
