using UnityEngine;

public class PlayerBahavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    
    void Start() => rb = gameObject.GetComponent<Rigidbody2D>();

    void Update() => Move();

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(horizontal * speed , rb.linearVelocity.y);
    }
}
