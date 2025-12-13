using UnityEngine;
using UnityEngine.Rendering.UI;

public class WallBehavior : MonoBehaviour
{
    [SerializeField] private GameObject explodePrefab;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private AudioClip asteroidExplodeClip;
    
    private int wallLife = 5;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (wallLife == 0)
        {
            AudioManager.Instance.PlaySfx(asteroidExplodeClip);
            spriteRenderer.enabled = false;
            GameObject explosion = Instantiate(explodePrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(explosion, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            wallLife -= 1;
        }

        if (collision.gameObject.tag == "BadBullet")
        {
            wallLife -= 1;
        }
    }
}
