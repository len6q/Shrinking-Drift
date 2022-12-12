using UnityEngine;
using System;
using System.Runtime.InteropServices;

[Serializable]
public class PlayerDate
{
    public float BestScore = float.MaxValue;

    public int PlayCount = 1;
}

public class PlayerSettings : MonoBehaviour
{
    public PlayerDate PlayerDate;

    public static PlayerSettings Instance;

    private string _currentLanguage;

    [DllImport("__Internal")]
    private static extern string GetLang();

    private void Awake()
    {
        if(Instance == null)
        {
            _currentLanguage = GetLang();

            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadExtern();
        }
    }

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerDate);
        SaveExtern(jsonString);
    }

    public void Load(string date)
    {
        PlayerDate = JsonUtility.FromJson<PlayerDate>(date);
    }

    public string GetLanguage() => _currentLanguage;    
}
