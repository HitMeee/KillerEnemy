using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public GameObject gameOverPanel; 
    public TMP_Text levelTMP;
    public Button RestartGame;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (RestartGame != null)
        {
            RestartGame.onClick.AddListener(Restart);
        }
    }

    void Update()
    {

        if (levelTMP != null)
        {
            var spawner = FindObjectOfType<EnemySpawner>();
            levelTMP.text = spawner != null ? $"LEVEL: {spawner.currentLevel}" : "LEVEL: -";
        }
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}