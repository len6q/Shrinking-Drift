using UnityEngine;

public class Planet : MonoBehaviour
{
    public static float ShrinkSpeed => .02f;

    public static float Scale => _planet.localScale.x;    

    private static Transform _planet;

    private void Awake() => _planet = transform;

    private void Update() => transform.localScale *= 1f - ShrinkSpeed * Time.deltaTime;

}
