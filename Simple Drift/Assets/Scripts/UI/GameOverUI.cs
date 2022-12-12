using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Player _car;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Text _gameOverText;

    private void Start()
    {                
        _car.OnDead += ShowGameOverText;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _car.OnDead -= ShowGameOverText;
    }

    public void QuitMenu()
    {
        PlayerSettings.Instance.PlayerDate.PlayCount++;
        if(PlayerSettings.Instance.PlayerDate.PlayCount % 2 == 0)
        {

        }

        SceneLoader.Instance.LoadMenu();
    }

    private void ShowGameOverText()
    {
        _joystick.gameObject.SetActive(false);
        
        if(Planet.Scale < PlayerSettings.Instance.PlayerDate.BestScore)
        {
            PlayerSettings.Instance.PlayerDate.BestScore = Planet.Scale;
        }        

        gameObject.SetActive(true);
        _gameOverText.text = "press \"Space\" to start";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerSettings.Instance.PlayerDate.PlayCount++;
        if (PlayerSettings.Instance.PlayerDate.PlayCount % 2 == 0)
        {

        }

        SceneLoader.Instance.LoadMain();
    }
}
