using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        gameObject.transform.position += new Vector3(-speed * Time.deltaTime,0,0);
    }
}
