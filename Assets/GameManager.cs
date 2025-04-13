using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI timeText;      // Hiển thị thời gian
    public TextMeshProUGUI resultText;    // Hiển thị kết quả

    private float timer = 0f;
    private bool isPlaying = true;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            timeText.text = "⏳ Time: " + timer.ToString("F2") + "s";  // Dùng ⏳ thay cho ⏱
        }
    }


    public void FinishGame()
    {
        isPlaying = false;
        float finalTime = timer;
        Debug.Log("🎉 Game Complete! Time: " + finalTime.ToString("F2") + "s");

        if (resultText != null)
        {
            resultText.text = "🎉 You Win!\nTime: " + finalTime.ToString("F2") + "s";
        }
    }
}
    