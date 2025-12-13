using UnityEngine;

public class CarManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject carPrefabLeft;
    [SerializeField] private GameObject carPrefabRight;

    [Header("Cooldowns")]
    [SerializeField] private float coolDownL1 = 12f;
    [SerializeField] private float coolDownL3 = 2.5f;
    [SerializeField] private float coolDownL2 = 12f;
    [SerializeField] private float coolDownL4 = 10f;
    
    void Update() => Cooldown();

    void Cooldown()
    {
        if (coolDownL1 <= 0)
            SpawCarL1();
        else
            coolDownL1 -= Time.deltaTime;


        if (coolDownL3 <= 0)
            SpawCarL3();
        else
            coolDownL3 -= Time.deltaTime;


        if (coolDownL2 <= 0)
            SpawCarL2();
        else
            coolDownL2 -= Time.deltaTime;


        if (coolDownL4 <= 0)
            SpawCarL4();
        else
            coolDownL4 -= Time.deltaTime;
    }

    void SpawCarL1()
    {
        Instantiate(carPrefabLeft, new Vector3(12,-3.2f,0), Quaternion.identity);
        Instantiate(carPrefabLeft, new Vector3(13, -3.2f, 0), Quaternion.identity);
        coolDownL1 = 12f;
    }

    void SpawCarL3()
    {
        Instantiate(carPrefabLeft, new Vector3(12, -0.35f, 0), Quaternion.identity);
        coolDownL3 = 2.5f;
    }

    void SpawCarL2()
    {
        Instantiate(carPrefabRight, new Vector3(-12, -1.8f, 0), Quaternion.identity);
        Instantiate(carPrefabRight, new Vector3(-13, -1.8f, 0), Quaternion.identity);

        Instantiate(carPrefabRight, new Vector3(-16, -1.8f, 0), Quaternion.identity);
        Instantiate(carPrefabRight, new Vector3(-17, -1.8f, 0), Quaternion.identity);

        Instantiate(carPrefabRight, new Vector3(-20, -1.8f, 0), Quaternion.identity);
        Instantiate(carPrefabRight, new Vector3(-21, -1.8f, 0), Quaternion.identity);
        coolDownL2 = 12f;
    }

    void SpawCarL4()
    {
        Instantiate(carPrefabRight, new Vector3(-12, 0.99f, 0), Quaternion.identity);
        Instantiate(carPrefabRight, new Vector3(-13, 0.99f, 0), Quaternion.identity);
        Instantiate(carPrefabRight, new Vector3(-14, 0.99f, 0), Quaternion.identity);

        Instantiate(carPrefabRight, new Vector3(-18, 0.99f, 0), Quaternion.identity);
        Instantiate(carPrefabRight, new Vector3(-19, 0.99f, 0), Quaternion.identity);
        Instantiate(carPrefabRight, new Vector3(-20, 0.99f, 0), Quaternion.identity);
        coolDownL4 = 10f;
    }
}
