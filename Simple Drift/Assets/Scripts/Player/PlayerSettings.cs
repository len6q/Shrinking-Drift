using UnityEngine;

public class PlayerSettings
{
    public static float BestScore
    {
        get
        {
            return PlayerPrefs.GetFloat("BestScore");
        }
        set
        {
            if (!PlayerPrefs.HasKey("BestScore"))
                PlayerPrefs.SetFloat("BestScore", float.MaxValue);

            if (value < PlayerPrefs.GetFloat("BestScore"))
                PlayerPrefs.SetFloat("BestScore", value);
        }
    }
}
