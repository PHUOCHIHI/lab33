using UnityEngine;

public class EnemyVerticalGroupController : MonoBehaviour
{
    public Transform[] enemies;
    public float moveSpeed = 2f;

    private int direction = -1; // -1 = xuống, 1 = lên

    void Update()
    {
        Vector3 move = Vector3.up * direction * moveSpeed * Time.deltaTime;
        foreach (Transform enemy in enemies)
        {
            enemy.Translate(move);
        }
    }

    public void ReverseDirection()
    {
        direction *= -1;
    }
}
    