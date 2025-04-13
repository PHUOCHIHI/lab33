using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuContdroller : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Lấy nút PLAY GAME theo tên
        var playBtn = root.Q<Button>("PLAY");

        // Gán sự kiện bấm nút
        playBtn.clicked += () =>
        {
            Debug.Log("Đã bấm PLAY GAME");
            SceneManager.LoadScene("dsxa"); // ✅ Tên chính xác scene bạn muốn load
        };
    }
}
