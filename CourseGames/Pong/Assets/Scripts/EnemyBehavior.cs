using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float speed;

    GameObject ballToFollow;

    void Start() => ballToFollow = GameObject.FindGameObjectWithTag("Ball");

    void Update() => FollowBall();

    void FollowBall()
    {
        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, ballToFollow.transform.position.y, speed * Time.deltaTime));
    }
}
