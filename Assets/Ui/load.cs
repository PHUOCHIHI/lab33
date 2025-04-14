using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuContdroller : MonoBehaviour
{
    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("Không tìm thấy UIDocument trên GameObject!");
            return;
        }

        var root = uiDocument.rootVisualElement;
        var playBtn = root.Q<Button>("PLAY");

        if (playBtn == null)
        {
            Debug.LogError("Không tìm thấy nút có tên 'PLAY' trong UI Builder!");
            return;
        }

        playBtn.clicked += () =>
        {
            Debug.Log("Đã bấm PLAY GAME");

            if (Application.CanStreamedLevelBeLoaded("dsxa"))
            {
                SceneManager.LoadScene("dsxa");
            }
            else
            {
                Debug.LogError("Scene 'dsxa' chưa được thêm vào Build Settings hoặc tên bị sai!");
            }
        };
    }
}
