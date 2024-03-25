using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float delay = 3f; 
    public float blastRadius = 5f; 
    public float explosionForce = 700f; 
    public float attackDamage = 25f; 
    private HashSet<GameObject> damagedObjects = new HashSet<GameObject>(); 

    public void AttackEnemy(GameObject other)
    {
        if (damagedObjects.Contains(other))
        {
            return;
        }

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(attackDamage);
            damagedObjects.Add(other); 
        }


        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(attackDamage);
            damagedObjects.Add(other); 
        }
    }
    private void Start()
    {
        Invoke("Explode", delay);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
            AttackEnemy(nearbyObject.gameObject);
        }
        Destroy(gameObject); 
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        
    }
}