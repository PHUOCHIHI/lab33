using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool moveDown;
    public float moveSpeed = 3f;

    void Update()
    {
        // Di chuyển lên hoặc xuống theo hướng
        if (moveDown)
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu chạm vào tường thì đổi hướng
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveDown = !moveDown;
        }
    }
}