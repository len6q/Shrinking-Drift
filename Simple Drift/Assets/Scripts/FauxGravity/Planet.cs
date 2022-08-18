using UnityEngine;

public class Planet : MonoBehaviour
{
    public static float ShrinkSpeed 
    {
        get { return .02f; }
        private set { }
    } 

    public static float Scale
    {
        get { return _planet.localScale.x; }
        private set { }
    }

    private static Transform _planet;

    private void Awake() => _planet = transform;

    private void Update() => transform.localScale *= 1f - ShrinkSpeed * Time.deltaTime;

}
