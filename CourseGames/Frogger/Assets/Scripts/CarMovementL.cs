using UnityEngine;

public class CarMovementL : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    
    void Start() => Destroy(this.gameObject, 17);

    void Update() => MoveLeft();

    void MoveLeft()
    {
        float speed = baseSpeed * Mathf.Max(1, ScoreManager.instance.score);
        gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }
}
