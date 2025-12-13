using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(this.gameObject);

        if (collision.gameObject.tag == "Scenario")
            Destroy(this.gameObject);
    }
}
