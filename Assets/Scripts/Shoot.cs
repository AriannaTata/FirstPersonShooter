using UnityEngine;


public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    void Shot()
    {
        /* RaycastHit hit;
          if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f)) //out = mi fa ritornare le informazioni del colpo, cosa è stato colpito
          {
              Debug.Log(hit.transform.name);
              Vector3 spawnPos = hit.point + (hit.normal * 0.01f); //viene posizionata un'immagine dove è avvenuto il colpo
              Quaternion spawnRotation = Quaternion.LookRotation(hit.normal); //l'immagine si posizionerà ruotata rispetto alla normale dell'oggetto dove viene posizionata
              GameObject impact = Instantiate(impactPrefab, spawnPos, spawnRotation);
              GameObject target = hit.collider.gameObject;

              impact.transform.SetParent(target.transform);
              Destroy(impact, 5f);
          }*/

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

       
        if (Physics.Raycast(ray, out hit, 100f))
        {
            targetPoint = hit.point;
        }
        else
        {
            
            targetPoint = ray.GetPoint(100f);
        }

       
        Vector3 direction = (targetPoint - firePoint.position).normalized;
       
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(direction * bulletForce, ForceMode.Impulse);
        }
    }

}
