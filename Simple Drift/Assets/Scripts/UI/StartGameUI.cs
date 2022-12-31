using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _bestScore;    
    [SerializeField] private Text _startText;
    [SerializeField] private Text _gameName;

    private void Start()
    {
        if(PlayerSettings.Instance.PlayerDate.BestScore == float.MaxValue)
        {
            _bestScore.text = "R = " + 0 + "m";
        }
        else
        {
            _bestScore.text = "R = " + PlayerSettings.Instance.PlayerDate.BestScore.ToString("0.00") + "m";
        }

        switch (PlayerSettings.Instance.GetLanguage())
        {
            case "ru":
                _startText.text = "НАЖМИ, ЧТОБЫ НАЧАТЬ";
                _gameName.text = "ПРОСТОЙ ДРИФТ";
                break;
            case "en":
                _startText.text = "CLICK TO START";
                _gameName.text = "SIMPLE DRIFT";
                break;
            case "tr":
                _startText.text = "BAŞLAMAK İÇİN TIKLA";
                _gameName.text = "BASİT SÜRÜKLENME";
                break;
            default:
                _startText.text = "CLICK TO START";
                _gameName.text = "SIMPLE DRIFT";
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneLoader.Instance.LoadMain();
    }
}
