using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private VisualElement menu;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

            menu = root.Q<VisualElement>("menu");
            var toggleButton = root.Q<Button>("toggleBtn");
            var PLAY = root.Q<Button>("PLAY");

        toggleButton.clicked += () =>
        {
            menu.style.display =
                menu.style.display == DisplayStyle.None ? DisplayStyle.Flex : DisplayStyle.None;
        };

        PLAY.clicked += () =>
        {
            Debug.Log("▶️ Loading Level1...");
            SceneManager.LoadScene("dsxa");
        };
    }
}
