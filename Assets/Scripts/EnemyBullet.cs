using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public AudioClip splatSound;
    void OnCollisionEnter(Collision collision)
   {
        if (splatSound != null)
        {
            AudioSource.PlayClipAtPoint(splatSound, transform.position, 0.5f);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
        }
        Destroy(gameObject);
   }
}
