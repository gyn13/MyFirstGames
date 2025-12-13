using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject wallPrefab;
    ScoreManager scoreManager;
    
    public float coolDown = 3;
    private float initialCD;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialCD = coolDown;
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();
    }

    void Cooldown()
    {
        if(coolDown <= 0)
        {
            SpawnObstacle();
            coolDown = 3 - scoreManager.score / 10f;
        }
        else
        {
            coolDown -= Time.deltaTime;
        }
    }

    void SpawnObstacle()
    {
        Instantiate(wallPrefab, new Vector3(5, Random.Range(-3, 3), 0), Quaternion.identity);
    }
}
