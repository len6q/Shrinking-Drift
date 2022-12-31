using System.Runtime.InteropServices;
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

    [DllImport("__Internal")]
    private static extern void ShowADS();

    public void QuitMenu()
    {
        PlayerSettings.Instance.PlayerDate.PlayCount++;
        if(PlayerSettings.Instance.PlayerDate.PlayCount % 3 == 0)
        {
            ShowADS();
        }

        PlayerSettings.Instance.Save();
        SceneLoader.Instance.LoadMenu();
    }

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    private void ShowGameOverText()
    {
        _joystick.gameObject.SetActive(false);
        
        if(Planet.Scale < PlayerSettings.Instance.PlayerDate.BestScore)
        {
            PlayerSettings.Instance.PlayerDate.BestScore = Planet.Scale;
            SetToLeaderboard((int)(PlayerSettings.Instance.PlayerDate.BestScore * 100));
            PlayerSettings.Instance.Save();
        }        

        gameObject.SetActive(true);

        switch (PlayerSettings.Instance.GetLanguage())
        {
            case "ru":
                _gameOverText.text = "НАЖМИ, ЧТОБЫ НАЧАТЬ";
                break;
            case "en":
                _gameOverText.text = "CLICK TO START";
                break;
            case "tr":
                _gameOverText.text = "BAŞLAMAK İÇİN TIKLA";
                break;
            default:
                _gameOverText.text = "CLICK TO START";
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerSettings.Instance.PlayerDate.PlayCount++;
        if (PlayerSettings.Instance.PlayerDate.PlayCount % 3 == 0)
        {
            ShowADS();
        }

        PlayerSettings.Instance.Save();
        SceneLoader.Instance.LoadMain();
    }
}
