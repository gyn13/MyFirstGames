using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject gameOver;
    
    [SerializeField] private AudioClip playerExplodeClip;

    void FixedUpdate() => Move();

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 move = new Vector2(horizontal, 0);

        gameObject.GetComponent<Rigidbody2D>().AddForce(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BadBullet")
        {
            AudioManager.Instance.PlaySfx(playerExplodeClip);
            Destroy(this.gameObject);
            gameOver.SetActive(true);
        }
    }
}
