using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _gameName;
    [SerializeField] private Text _startText;

    private void Start()
    {
        _bestScore.text = "R = " + PlayerSettings.GetBestScore().ToString("0.00") + "m";
        _gameName.text = "Shrinking Drift";
        _startText.text = "press \"Space\" to start";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneLoader.Instance.LoadMain();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
