using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour
{
    [SerializeField] private FauxGravityAttractor _attractor;
    [SerializeField] private bool _placeOnSurface;

    private Rigidbody _body;

    private void Start() => _body = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        if (_placeOnSurface)
            _attractor.PlaceOnSurface(_body);
        else
            _attractor.Attract(_body);
    }
}
