using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  
    public int count = 0;             
    public void Init()
    {

    }
    void Start()
    {
        count = PlayerPrefs.GetInt("KilledEnemy", 0);
        scoreText.text = "Last Score: " + count;
    }

    public void AddCount()
    {
        count++; // +1 khi giết quái
        PlayerPrefs.SetInt("KilledEnemy", count); 
        PlayerPrefs.Save();

        // Cập nhật giao diện
        scoreText.text = "KILLED ENEMY: " + count;

    }
}
