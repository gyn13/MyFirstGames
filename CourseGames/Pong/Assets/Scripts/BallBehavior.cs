using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour
{
    [Header("Ball Settings")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    
    [Header("Audio")]
    [SerializeField] private AudioClip playerPointClip;
    [SerializeField] private AudioClip enemyPointClip;
    [SerializeField] private AudioClip ballHitClip;

    ScoreManager scoreManager;

    Vector2 startPosi;

    void Start()
    {
        startPosi = this.transform.position;
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        Launch();
        
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    private void Launch()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerPoint")
        {
            scoreManager.scorePlayer += 1;
            this.transform.position = startPosi;
            AudioManager.Instance.PlaySfx(playerPointClip);
        }
    
        if (collision.gameObject.tag == "EnemyPoint")
        {
            scoreManager.scoreEnemy += 1;
            this.transform.position = startPosi;
            AudioManager.Instance.PlaySfx(enemyPointClip);
        }
        
        if(collision.gameObject.tag == "Wall")
            AudioManager.Instance.PlaySfx(ballHitClip);
        
        if (collision.gameObject.tag == "Player")
            AudioManager.Instance.PlaySfx(ballHitClip);
        
        if (collision.gameObject.tag == "Enemy")
            AudioManager.Instance.PlaySfx(ballHitClip);
    }
}
