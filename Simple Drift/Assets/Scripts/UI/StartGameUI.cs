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

        _startText.text = "press \"Space\" to start";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneLoader.Instance.LoadMain();
    }
}
