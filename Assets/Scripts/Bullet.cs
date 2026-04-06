using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitPrefab;
    public float lifeTime = 3f;
    public AudioClip splatSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

   void OnCollisionEnter(Collision collision)
    {
        if(splatSound!= null)
        {
            AudioSource.PlayClipAtPoint(splatSound, transform.position, 0.5f);
        }
        ContactPoint contact = collision.contacts[0];
        Vector3 spawnPos = contact.point + (contact.normal * 0.01f);
        Quaternion spawnRotation = Quaternion.LookRotation(contact.normal);

        GameObject hit = Instantiate(hitPrefab, spawnPos, spawnRotation);

        hit.transform.SetParent(collision.transform);
        Destroy(hit, 5f);

        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if(enemy != null)
        {
            enemy.TakeHit();
        }

        Destroy(gameObject);
    }
}
