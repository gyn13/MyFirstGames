using UnityEngine;

public class CarMovementR : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    
    void Start() => Destroy(this.gameObject, 17);

    void Update() => MoveRight();

    void MoveRight()
    {
        float speed = baseSpeed * Mathf.Max(1, ScoreManager.instance.score);
        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
