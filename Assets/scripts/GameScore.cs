using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    public TMP_Text scoreTextUI;

    private int score = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateScoreTextUI();
        }
    }

    void Start()
    {
        UpdateScoreTextUI();
    }

    void UpdateScoreTextUI()
    {
        scoreTextUI.text = score.ToString("000000");
    }

    // Удобный метод для добавления очков
    public void AddScore(int amount)
    {
        Score += amount;
    }
}
