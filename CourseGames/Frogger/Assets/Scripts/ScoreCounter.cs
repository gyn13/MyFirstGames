using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    ScoreManager scoreManager;

    float points;

    void Start() => scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();

    private void OnTriggerEnter2D(Collider2D collision) => points = scoreManager.score += 1;
}
