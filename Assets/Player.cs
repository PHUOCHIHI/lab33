using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform spawnPoint;
    public float speed = 5f;
    private Vector2 lastPosition;
    private Rigidbody2D rb;

    public AudioClip enemyHitSound; // Âm thanh va chạm với Enemy
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Tìm đối tượng có tag "Respawn"
        GameObject spawnObject = GameObject.FindGameObjectWithTag("Respawn");
        if (spawnObject != null)
        {
            spawnPoint = spawnObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng với tag 'Respawn'!");
        }

        // Gán hoặc thêm AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
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

        // Nếu chạm vào Enemy, phát âm thanh rồi hồi sinh
        if (collision.gameObject.CompareTag("Enemy") && spawnPoint != null)
        {
            if (enemyHitSound != null)
            {
                audioSource.PlayOneShot(enemyHitSound);
            }

            // Đợi một chút để âm thanh phát xong trước khi dịch chuyển
            Invoke(nameof(Respawn), 0.2f);
        }

        // Nếu chạm vào Winner, in ra log "Winner"
        if (collision.gameObject.CompareTag("Winner"))
        {
            Debug.Log("Winner");
        }
    }

    private void Respawn()
    {
        transform.position = spawnPoint.position;
    }
}
