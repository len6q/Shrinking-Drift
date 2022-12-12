using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _bestScore;    
    [SerializeField] private Text _startText;

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
                _startText.text = "Õ¿∆Ã», ◊“Œ¡€ Õ¿◊¿“‹";
                break;
            case "en":
                _startText.text = "CLICK TO START";
                break;
            default:
                _startText.text = "CLICK TO START";
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneLoader.Instance.LoadMain();
    }
}
