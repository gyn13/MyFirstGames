using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public GameObject gameOver;
    public Animator animator;
    [SerializeField] private AudioClip dieClip;

    public float jumpForce; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocityY = jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            this.enabled = false;
            animator.Play("Die");
            AudioManager.Instance.PlaySfx(dieClip);
            gameOver.SetActive(true);
        }
    }
}
