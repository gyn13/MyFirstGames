using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [Header("Sprites")]
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    private SpriteRenderer spriteRenderer;

    [Header("Audio")]
    [SerializeField] private AudioClip dieClip;
    [SerializeField] private AudioClip jumpClip;
    private bool isDead = false;

    [SerializeField] private GameObject deathVfxPrefab;
    
    void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!isDead)
        {
            Movement();
        }
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + new Vector2(0, 1.4f));
            spriteRenderer.sprite = upSprite;
            AudioManager.Instance.PlaySfx(jumpClip);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + new Vector2(0, -1.4f));
            spriteRenderer.sprite = downSprite;
            AudioManager.Instance.PlaySfx(jumpClip);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + new Vector2(-1.4f, 0));
            spriteRenderer.sprite = leftSprite;
            AudioManager.Instance.PlaySfx(jumpClip);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + new Vector2(1.4f, 0));
            spriteRenderer.sprite = rightSprite;
            AudioManager.Instance.PlaySfx(jumpClip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DelayedDeath());
        }
    }

    private IEnumerator DelayedDeath()
    {
        AudioManager.Instance.PlaySfx(dieClip);
        isDead = true;
        spriteRenderer.enabled = false;
        Instantiate(deathVfxPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(this.gameObject);
    }
}
