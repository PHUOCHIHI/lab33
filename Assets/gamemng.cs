using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerrr : MonoBehaviour
{
    public UIDocument winnerUIDocument;

    void Start()
    {
        if (winnerUIDocument != null)
        {
            winnerUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        }
    }

    public void ShowWinnerScreen()
    {
        if (winnerUIDocument != null)
        {
            winnerUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        }
        else
        {
            Debug.LogError("Winner UIDocument chưa được gán!");
        }
    }
}
