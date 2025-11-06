using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Kéo TMP vào đây trong Inspector
    public int count = 0;              // Số quái đã giết
    public void Init()
    {

    }
    void Start()
    {
        // Lấy dữ liệu đã lưu, nếu chưa có thì = 0
        count = PlayerPrefs.GetInt("KilledEnemy", 0);
        scoreText.text = "Last Score: " + count;
    }

    public void AddCount()
    {
        count++; // +1 khi giết quái
        PlayerPrefs.SetInt("KilledEnemy", count); // Lưu lại
        PlayerPrefs.Save();

        // Cập nhật giao diện
        scoreText.text = "KILLED ENEMY: " + count;

    }
}
