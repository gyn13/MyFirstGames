using UnityEngine;

public class CityManager : MonoBehaviour
{
    public GameObject cityPrefab;
    
    [SerializeField] private float cd = 7f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnInitialCity();
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();
    }

    void Cooldown()
    {
        if (cd <= 0)
        {
            SpawnCity();
            cd = 4.5f;
        }
        else
        {
            cd -= Time.deltaTime;
        }
    }

    void SpawnInitialCity()
    {
        Instantiate(cityPrefab, new Vector3(11.85f, 0.077f, 0), Quaternion.identity);
    }
    
    void SpawnCity()
    {
        Instantiate(cityPrefab, new Vector3(17f, 0.077f, 0), Quaternion.identity);
    }
}
