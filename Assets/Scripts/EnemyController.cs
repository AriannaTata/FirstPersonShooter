using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public Transform player;

    [Header("Movimento")]
    public float speed;
    public float fleeDistance = 6f;
    public float startFleeingDistance = 5f;
    public float stopChasingDistance = 20f;

    [Header("Combattimento")]
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.5f;
    public float attackRange = 15;
    private float nextFireTime;

    private NavMeshAgent agent;
    public GameObject impactPrefab;
    public int hitNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

       
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (hitNum >= 3)
        {
            Flee(); 
        }
        if (distanceToPlayer < startFleeingDistance)
        {
            Flee();
        }
        else if(distanceToPlayer > stopChasingDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath();
        }

        if (distanceToPlayer <= attackRange && Time.time >= nextFireTime)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + fireRate;
        }
            Death();
    }

    void ShootAtPlayer()
    {
        Vector3 lookPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookPos);
        //transform.LookAt(new Vector3(player.position.x, transform.position.y, firePoint.position.z));

        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 targetDir = (player.position + Vector3.up *1.5f - firePoint.position).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(targetDir * 20f, ForceMode.Impulse);
        }
    }
    void Flee()
    {
        Vector3 dirToPlayer = transform.position - player.position;

        Vector3 newPos = transform.position + dirToPlayer.normalized * fleeDistance;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(newPos, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            agent.speed = speed * 1.5f;
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hitNum++;
            impactPrefab.transform.parent = transform;
        }

    }*/

    public void TakeHit()
    {
        hitNum++;
        if (hitNum == 3)
        {
            
            GetComponent<Renderer>().material.color = Color.red;
            
        }
        if (hitNum >=5)
        {
            Death();
        }
            
    }

    void Death()
    {
        
        if (hitNum >= 5)
        {
           // SpawnManager manager = Object.FindFirstObjectByType<SpawnManager>();

            /*if (manager != null)
            {
                manager.RequestRespawn();
            }*/
            Destroy(gameObject);
        }
    }

}
