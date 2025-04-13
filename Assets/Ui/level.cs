using UnityEngine;
using UnityEngine.UIElements;

public class LevelInfo : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // 👉 Lấy khung hiển thị
        var levelBox = root.Q<VisualElement>("level");

        // ✅ Hiển thị khung "level" khi vào màn chơi
        levelBox.style.display = DisplayStyle.Flex;

        // 👉 Lấy 2 label bên trong
        var stageName = root.Q<Label>("stageName"); 
        var lifeCount = root.Q<Label>("lifeCount");

        // 👉 Cập nhật nội dung
        stageName.text = "Level: Menu";
        lifeCount.text = "Lượt: 3";
    }
}
