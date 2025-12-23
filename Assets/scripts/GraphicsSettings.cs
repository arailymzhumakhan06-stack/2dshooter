using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    public void SetQuality(int level)
    {
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt("Quality", level);
    }

    void Start()
    {
        int quality = PlayerPrefs.GetInt("Quality", 1);
        QualitySettings.SetQualityLevel(quality);
    }
}
