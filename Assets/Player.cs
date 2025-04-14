using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform spawnPoint;
    public float speed = 5f;
    private Vector2 lastPosition;
    private Rigidbody2D rb;

    public AudioClip enemyHitSound; // Âm thanh va chạm với Enemy
    private AudioSource audioSource;
    private GameManagerrr gameManager;


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
        gameManager = FindObjectOfType<GameManagerrr>();
        if (gameManager == null)
        {
            Debug.LogError("Không tìm thấy GameManager trong scene!");
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

        if (collision.gameObject.CompareTag("Enemy") && spawnPoint != null)
        {
            if (enemyHitSound != null)
            {
                audioSource.PlayOneShot(enemyHitSound);
            }

            Invoke(nameof(Respawn), 0.2f);
        }

        // Đây là chỗ bạn nên chèn thêm:
        if (collision.gameObject.CompareTag("Winner"))
        {
            Debug.Log("Winner");
            if (gameManager != null)
            {
                gameManager.ShowWinnerScreen();
            }
        }
    }


    private void Respawn()
    {
        transform.position = spawnPoint.position;
    }
}
