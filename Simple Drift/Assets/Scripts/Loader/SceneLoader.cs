using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneLoader: MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 1f;

    private void Start()
    {
        if (Instance == null) 
            Instance = this;
    }

    public void LoadMain()
    {
        StartCoroutine(LoadLevel("Main"));
    }
    
    public void LoadMenu()
    {
        StartCoroutine(LoadLevel("Menu"));
    }
    
    private IEnumerator LoadLevel(string nameScene)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(nameScene);
    }
}
