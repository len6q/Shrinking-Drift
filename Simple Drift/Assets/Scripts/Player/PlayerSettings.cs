using UnityEngine;

public class PlayerSettings
{
    public static float BestScore
    {
        get => PlayerPrefs.GetFloat("BestScore");        
        set
        {
            if (!PlayerPrefs.HasKey("BestScore"))
                PlayerPrefs.SetFloat("BestScore", float.MaxValue);

            if (value < BestScore)
                PlayerPrefs.SetFloat("BestScore", value);
        }
    }
}
