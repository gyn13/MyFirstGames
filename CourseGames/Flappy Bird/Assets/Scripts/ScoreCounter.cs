using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    ScoreManager scoreManager;

    [SerializeField] private AudioClip pointClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreManager.score += 1;
        AudioManager.Instance.PlaySfx(pointClip);
    }
}
