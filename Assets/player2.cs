using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private int totalCoins;
    private int collectedCoins = 0;
    private Vector3 spawnPosition;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Tìm vị trí spawn
        GameObject spawn = GameObject.FindGameObjectWithTag("Respawn");
        if (spawn != null)
        {
            spawnPosition = spawn.transform.position;
            transform.position = spawnPosition; // đặt player tại vị trí spawn
        }

        // Đếm tổng số coin

        void Update()
        {
            // Nhận input di chuyển trái/phải
            float moveX = Input.GetAxisRaw("Horizontal");
            moveDirection = new Vector2(moveX, 0);
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Chạm Enemy → quay về Spawn");
                transform.position = spawnPosition;
            }

            if (other.CompareTag("coin"))
            {
                collectedCoins++;
                Debug.Log("Thu thập coin: " + collectedCoins + "/" + totalCoins);
                Destroy(other.gameObject);
            }



        }
    }
}
