using UnityEngine;

public class Stomp : MonoBehaviour
{
    public ScoreManager scoreManager;

    [SerializeField] private AudioClip blockClip;
    [SerializeField] private AudioClip stompClip;

    private void Start() => scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WeakPoint")
        {
            Destroy(collision.transform.parent.gameObject);
            SoundManager.Instance.PlaySfx(stompClip);
            scoreManager.score += 1;
        }

        if(collision.gameObject.tag == "BlockWP")
        {
            Destroy(collision.transform.parent.gameObject);
            SoundManager.Instance.PlaySfx(blockClip);
            scoreManager.score += 1;
        }
    }
}
