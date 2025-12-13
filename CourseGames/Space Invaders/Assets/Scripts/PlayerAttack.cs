using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float bulletSpeed;
    
    [SerializeField] private AudioClip projectileClip;

    float cooldown;
    bool canAttack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * bulletSpeed, ForceMode2D.Impulse);
            AudioManager.Instance.PlaySfx(projectileClip);

            canAttack = false;
            cooldown = 0;
        }

        Cooldown();
    }

    void Cooldown()
    {
        if (cooldown > 0.35 && !canAttack)
            canAttack = true;
        else
            cooldown += Time.deltaTime;
    }
}
