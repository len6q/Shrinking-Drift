using UnityEngine;
using System;

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

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
