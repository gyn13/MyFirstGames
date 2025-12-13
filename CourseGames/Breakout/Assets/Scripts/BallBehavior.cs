using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float ballSpeed;

    [SerializeField] private GameObject gameOver;

    public GameOver restart;
    bool canReset = false;

    [SerializeField] private AudioClip blockPointClip;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip hitBackClip;

    ScoreManager scoreManager;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        Launch();

        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (canReset == true && Input.GetKeyDown(KeyCode.Space))
            restart.Restart();
    }
    
    private void Launch()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * ballSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
            scoreManager.score += 1;
            AudioManager.Instance.PlaySfx(blockPointClip);
        }
        
        if (collision.gameObject.tag == "Wall")
            AudioManager.Instance.PlaySfx(hitBackClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            gameOver.SetActive(true);
            AudioManager.Instance.PlaySfx(gameOverClip);
        }

        canReset = true;
    }
}
