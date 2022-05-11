using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text _score;
 
    private void Start()
    {
        _score = GetComponent<Text>();
    }

    private void Update()
    {
        _score.text = "R = " + Planet.Score.ToString("0.00") + "m";
    }
}
