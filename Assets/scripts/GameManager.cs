using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayerControl playerShip;

    [Header("Game Over UI")]
    public GameObject gameOverUI; // сюда перетащи свой спрайт или панель Game Over
    public float gameOverDelay = 2f; // через сколько секунд перейти в меню

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        playerShip.gameObject.SetActive(true);
        playerShip.Init();
        Time.timeScale = 1f;

        // Скрываем Game Over UI при старте
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        // Показываем спрайт Game Over
        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        // Останавливаем игру
        Time.timeScale = 0f;

        StartCoroutine(GoToMenuCoroutine());
    }

    private IEnumerator GoToMenuCoroutine()
    {
        // Ждём 2 секунды по обычному времени (Time.unscaledTime)
        yield return new WaitForSecondsRealtime(gameOverDelay);

        // Включаем время перед сменой сцены
        Time.timeScale = 1f;

        // Загружаем сцену меню
        SceneManager.LoadScene("MainMenu");
    }

    void GoToMenu()
    {
        // Включаем время перед сменой сцены
        Time.timeScale = 1f;

        // Замените "MainMenu" на название вашей сцены меню
        SceneManager.LoadScene("MainMenu");
    }
}
