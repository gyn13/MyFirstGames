using UnityEngine;

public class RespawnFrog : MonoBehaviour
{
    [Header("Respawn")]
    [SerializeField] private GameObject frog;
    [SerializeField] private Transform respawnPoint;

    [Header("Audio")]
    [SerializeField] private AudioClip pointClip;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySfx(pointClip);
            frog.transform.position = respawnPoint.position;
        }
    }
}
