using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    ScoreManager scoreManager;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float vertical = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * speed);
    }
}
