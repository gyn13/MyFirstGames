using UnityEngine;

public class AlienAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float bulletSpeed;
    float coolDown;
    float cdDuration = 5f;
    bool canAttack = true;

    void Update()
    {
        if(canAttack)
        {
            if(Random.Range(0, 100) < 30 && Random.Range(0, 100) > 70)
                Attack();

            canAttack = false;
            coolDown = 0;
        }

        Cooldown();
    }

    void Attack()
    {
        GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);

        projectileInstance.GetComponent<Rigidbody2D>().AddForce(Vector3.down * bulletSpeed, ForceMode2D.Impulse);
    }

    void Cooldown()
    {
        if (!canAttack)
        {
            coolDown += Time.deltaTime;
            if (coolDown >= cdDuration)
                canAttack = true;
        }
    }
}
