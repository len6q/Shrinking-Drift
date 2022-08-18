using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player _car;
    
    private Text _gameOverText;

    private void Start()
    {
        _gameOverText = GetComponent<Text>();
        _gameOverText.gameObject.SetActive(false);
        _car.OnDead += ShowGameOverText;        
    }

    private void OnDestroy()
    {
        _car.OnDead -= ShowGameOverText;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneLoader.Instance.LoadMain();

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneLoader.Instance.LoadMenu();            
    }

    private void ShowGameOverText()
    {
        PlayerSettings.BestScore = Planet.Scale;

        _gameOverText.gameObject.SetActive(true);
        _gameOverText.text = "press \"Space\" to start";
    }

}
