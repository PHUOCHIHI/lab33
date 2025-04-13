using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public List<GameObject> checkpointObjects;

    public void ShowCheckpointMessage(GameObject checkpointObj)
    {
        int index = checkpointObjects.IndexOf(checkpointObj);
        if (index >= 0)
        {
            Debug.Log("Checkpoint " + (index + 1));
            // Nếu muốn hiện UI thì có thể thêm code ở đây
        }
        else
        {
            Debug.LogWarning("Checkpoint không nằm trong danh sách!");
        }
    }
}
