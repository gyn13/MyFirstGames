using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    private int direction = 1;

    void Update() => Move();

    void Move() => transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyWall")
            direction = -direction;
    }
}
