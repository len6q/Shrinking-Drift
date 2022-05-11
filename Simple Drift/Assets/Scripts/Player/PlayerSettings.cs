using UnityEngine;

public static class PlayerSettings
{
    public static void SetBestScore(float score)
    {
        if (!PlayerPrefs.HasKey("BestScore"))
            PlayerPrefs.SetFloat("BestScore", float.MaxValue);

        if(score < PlayerPrefs.GetFloat("BestScore"))
            PlayerPrefs.SetFloat("BestScore", score);
    }
    public static float GetBestScore() => PlayerPrefs.GetFloat("BestScore");
   
}
