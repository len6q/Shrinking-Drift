using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
    private Text _score;
 
    private void Start() => _score = GetComponent<Text>();
    
    private void Update() => _score.text = "R = " + Planet.Scale.ToString("0.00") + "m";
    
}
