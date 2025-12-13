using UnityEngine;

public class BadProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(this.gameObject);

        if (collision.gameObject.tag == "Scenario")
            Destroy(this.gameObject);
    }
}
