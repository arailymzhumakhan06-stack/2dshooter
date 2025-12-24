using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    void Start()
    {
        // загружаем сохранённую настройку
        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = volume;
    }

    public void AudioOn()
    {
        AudioListener.volume = 1f;
        PlayerPrefs.SetFloat("Volume", 1f);
        PlayerPrefs.Save();
    }

    public void AudioOff()
    {
        AudioListener.volume = 0f;
        PlayerPrefs.SetFloat("Volume", 0f);
        PlayerPrefs.Save();
    }
}
