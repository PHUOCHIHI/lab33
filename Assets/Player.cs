using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform spawnPoint;
    public float speed = 5f;
    private Vector2 lastPosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Tìm đối tượng có tag "Spawn"
        GameObject spawnObject = GameObject.FindGameObjectWithTag("Respawn");
        if (spawnObject != null)
        {
            spawnPoint = spawnObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng với tag 'Spawn'!");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        lastPosition = rb.position;
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.MovePosition(lastPosition);
        }

        // Nếu chạm vào Enemy, reset về vị trí Spawn
        if (collision.gameObject.CompareTag("Enemy") && spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }

        // Nếu chạm vào Winner, in ra log "Winner"
        if (collision.gameObject.CompareTag("Winner"))
        {
            Debug.Log("Winner");
        }
    }
}
