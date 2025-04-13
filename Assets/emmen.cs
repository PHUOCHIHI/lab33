using UnityEngine;

public class EnemyGroupMover : MonoBehaviour
{
    public Transform[] enemies;
    public float moveSpeed = 2f;
    private int direction = 1;

    private Vector3 moveVector => Vector3.right * direction * moveSpeed * Time.deltaTime;

    void Update()
    {
        foreach (Transform enemy in enemies)
        {
            enemy.Translate(moveVector);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}
