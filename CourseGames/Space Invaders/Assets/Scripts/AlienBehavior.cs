using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDistance;
    
    [SerializeField] private AudioClip alienExplodeClip;

    private Vector3 startPosition;
    
    void Start() => startPosition = transform.position;

    void FixedUpdate() => Move();

    void Move()
    {
        float moveRep = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = startPosition + new Vector3(moveRep, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            AudioManager.Instance.PlaySfx(alienExplodeClip);
        }
    }
}
